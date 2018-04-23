using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFTWSharp;
using MLS_Gen_PC.Properties;

namespace MLS_Gen_PC
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            
            InitializeComponent();
            InitPanelFeedbacks();

            cmbFormatView.SelectedIndex = 0;
            cmbCorrelationMethod.SelectedIndex = 2;
            cmbPowNl.SelectedIndex = 1;
        }

        private void InitPanelFeedbacks()
        {
            for (int i = 0; i < 24; i++)
            {
                var cb = new CheckBox
                {
                    Name = "cb" + i.ToString(),
                    Tag = i,
                    Text = (i + 1).ToString(),
                    TabIndex = i,
                    Location = new Point(i * 40 + 3, 3),
                    AutoSize = true,
                    UseVisualStyleBackColor = true,
                };
                cb.CheckedChanged += Cb_CheckedChanged;
                panelFeedbacks.Controls.Add(cb);
            }
        }

        private void Cb_CheckedChanged(object sender, EventArgs e) 
        {
            if (!((Control) sender).Focused) return; //Если состояние изменилось программно - выходим
            ChangeFeedback(CbFeedback);
        }


        private int CbFeedback
        {
            get
            {
                int res = 0;
                foreach (CheckBox cb in panelFeedbacks.Controls)
                    if (cb.Checked) res |= 1 << (int)cb.Tag;
                return res;
            }
            set
            {
                foreach (CheckBox cb in panelFeedbacks.Controls)
                    cb.Checked = ((value >> (int) cb.Tag) & 1) != 0;
            }
        }

        

        private static string TimeToText(long sec)
        {
            if (sec < 100) return $"{sec} секунд";
            sec = (sec + 30) / 60;
            if (sec < 100) return $"{sec} минут";
            sec = (sec + 30) / 60;
            if (sec < 40) return $"{sec} часов";
            sec = (sec + 12) / 24;
            return $"{sec} дней";
        }


        private bool LongTimeMessageNo(int n)
        {
            if (n < 16) return false;
            return MessageBox.Show($"Долго\r\nn = {n}\r\nt = {TimeToText((long)(7 * Math.Pow(4, n - 16)))}",
                       "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes;
        }

        private bool LongTimeMessageNo(long ct)
        {
            if (ct < 1000000L*1000) return false;
            return MessageBox.Show($"Долго\r\nct/1e6 = {ct / 1000000}\r\nt = {TimeToText((long)(ct/172e6))}",
                       "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes;
        }

        private SeqGen _seqGen = new SeqGen(0);
        private List<int> _allFbList = new List<int>();
        private List<int> _allCorPeakList = new List<int>();

        private void ChangeFeedback(SeqGen sg)
        {
            bool isChangePeriod = _seqGen.Period != sg.Period;
            _seqGen = new SeqGen(sg);
            ChangeFeedback(isChangePeriod, true);
        }

        private void ChangeFeedbackValid(int fb)
        {
            _seqGen.Feedback = fb;
            _seqGen.IsValid = true;
            ChangeFeedback(_seqGen.IsResize, true);
        }

        private void ChangeFeedback(int fb, bool isClearTextBox = true)
        {
            _seqGen.Feedback = fb;
            _seqGen.Validate();
            ChangeFeedback(_seqGen.IsResize, isClearTextBox);
        }

        private void UpdatePeriod()
        {
            var onePer = _seqGen.Period * DiscreteInMinPulse;
            txtFeedbackPeriod.Text = $"{onePer}";
            if(_seqGen.Nbits<2) return;
            numCorStart.Maximum = onePer;
            numCorEnd.Maximum = onePer;
            numCorEnd.Value = onePer;
        }

        private void ChangeFeedback(bool isChangePeriod, bool isClearTextBox)
        {
            if (isChangePeriod)
            {
                _allFbList.Clear();
                _allCorPeakList.Clear();
                txtAllFeedbacksList.Clear();

                btnSaveFile.Enabled = false;
                btnFindAllCorPeak.Enabled = false;
                txtFeedbackNbits.Text = $"{_seqGen.Nbits}";
                txtMaxFeedbackCnt.Text = $"{_seqGen.MaxFeedbackCount}";

                if (_seqGen.Period > 0)
                    numDiscreteInMinPulse.Maximum = Math.Min((1u << 28) / _seqGen.Period, 65535);

                UpdatePeriod();
            }

            CbFeedback = _seqGen.Feedback;

            if (_seqGen.IsValid)
            {
                txtSingleFeedbackIsMls.Text = "М-последовательность";
                txtSingleFeedbackDec.Text = $"{_seqGen.Feedback}";
                txtSingleFeedbackHex.Text = $"0x{_seqGen.Feedback:X8}";
                txtSingleFeedbackDec.BackColor = txtSingleFeedbackHex.BackColor = SystemColors.Window;
                btnBuildGraphics.Enabled = true;
            }
            else
            {
                txtSingleFeedbackIsMls.Text = "";
                if (isClearTextBox)
                {
                    txtSingleFeedbackDec.Text = "";
                    txtSingleFeedbackHex.Text = "";
                }
                txtSingleFeedbackDec.BackColor = txtSingleFeedbackHex.BackColor = Color.LightCoral;
                btnBuildGraphics.Enabled = false;
            }
        }

        private int DiscreteInMinPulse
        {
            get { return (int)numDiscreteInMinPulse.Value; }
            set { numDiscreteInMinPulse.Value = value; }
        }

        private void numDiscreteInMinPulse_ValueChanged(object sender, EventArgs e)
        {
            if (!((Control)sender).Focused) return;
            UpdatePeriod();
        }

        private void btnFindNextFeedback_Click(object sender, EventArgs e)
        {
            var sgv = new SeqGenValidator(_seqGen);
            for (int fb = sgv.Feedback+1; fb < (1<<24); fb++)
            {
                sgv.Feedback = fb;
                if (!sgv.Validate()) continue;
                ChangeFeedback(sgv);
                break;
            }
        }

       

        private void btnFindAllFeedback_Click(object sender, EventArgs e)
        {
            if(_seqGen.Nbits < 2) return;
            if (LongTimeMessageNo(_seqGen.Nbits)) return;
            var sgv = new SeqGenValidator(_seqGen);
            _allFbList = new List<int>(sgv.MaxFeedbackCount);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int fb = 1<<(sgv.Nbits-1); fb < (1 << sgv.Nbits); fb++)
            {
                sgv.Feedback = fb;
                if(sgv.Validate()) _allFbList.Add(fb);
            }
            sw.Stop();
            lblTime.Text = sw.ElapsedMilliseconds.ToString();
            UpdateFeedbacksList();

            btnSaveFile.Enabled = true;
            btnFindAllCorPeak.Enabled = true;
            numSaveStart.Maximum = _allFbList.Count;
            numSaveStart.Value = 1;
            numSaveLen.Maximum = _allFbList.Count;
            numSaveLen.Value = _allFbList.Count;
        }


        private void SbAppendVal(StringBuilder sb, int format, int val)
        {
            const int sbit = 24 - 1;
            switch (format)
            {
                case 0:
                    sb.AppendFormat("{0}", val);
                    break;
                case 1:
                    sb.AppendFormat("0x{0:X8}", val);
                    break;
                case 2:
                    sb.AppendFormat("0b");
                    for (var bi = 1u << sbit; bi > 0; bi >>= 1)
                    {
                        sb.Append(((val & bi) != 0 ? '1' : '0'));
                    }
                    break;
                case 3:
                    sb.AppendFormat("0x{0:X8},", val);
                    break;
                case 4:
                    for (int i = sbit; i > 0; i--)
                    {
                        var bi = 1u << i;
                        if ((val & bi) != 0) sb.AppendFormat("X^{0}+", i + 1);
                    }
                    if ((val & 1) != 0) sb.AppendFormat("X+");
                    sb.AppendFormat("1");
                    break;
            }
        }


        private void UpdateFeedbacksList()
        {
            if (!_allFbList.Any()) return;
            var format = cmbFormatView.SelectedIndex;
            if (format < 0) return;
            StringBuilder sb = new StringBuilder(_allFbList.Count * 25);

            for (int i = 0; i < _allFbList.Count; i++)
            {
                SbAppendVal(sb, format, _allFbList[i]);
                if (_allCorPeakList.Count == _allFbList.Count && format < 3)
                {
                    sb.Append(' ');
                    SbAppendVal(sb, format, _allCorPeakList[i] + 1);
                }
                sb.AppendLine();
            }

            var line = txtAllFeedbacksList.GetLineFromCharIndex(txtAllFeedbacksList.SelectionStart);
            txtAllFeedbacksList.Text = sb.ToString();
            if (line >= 0 && line < _allFbList.Count)
            {
                txtAllFeedbacksList.SelectionStart = txtAllFeedbacksList.GetFirstCharIndexFromLine(line);
            }
            txtAllFeedbacksList.ScrollToCaret();
        }

        private void cmbFormatView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!((Control)sender).Focused) return;
            UpdateFeedbacksList();
        }

        private void txtAllFeedbacksList_SelectionChanged(object sender, EventArgs e)
        {
            if (!((Control) sender).Focused) return;
            var rtb = (RichTextBox) sender;
            var line = rtb.GetLineFromCharIndex(rtb.SelectionStart);
            if (line >= _allFbList.Count || line < 0) return;
            ChangeFeedbackValid(_allFbList[line]);
        }



        private void txtSingleFeedbackHex_TextChanged(object sender, EventArgs e)
        {
            if (!((Control)sender).Focused) return;
            if (txtSingleFeedbackHex.Text.Length < 10) return;
            var txt = txtSingleFeedbackHex.Text.Trim();
            if(!txt.StartsWith("0x",true,CultureInfo.CurrentCulture) || txt.Length != 10) return;
            var res = 0;
            if(!int.TryParse(txt.Substring(2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out res)) return;
            ChangeFeedback(res, false);
        }

        private void txtSingleFeedbackDec_TextChanged(object sender, EventArgs e)
        {
            timChangeText.Stop();
            if (!((Control)sender).Focused) return;
            timChangeText.Tag = 10;
            timChangeText.Start();
        }

        private void timChangeText_Tick(object sender, EventArgs e)
        {
            timChangeText.Stop();
            if((int)timChangeText.Tag != 10) return;
            var txt = txtSingleFeedbackDec.Text;
            var res = 0;
            if (!int.TryParse(txt.Trim(), out res)) return;
            ChangeFeedback(res, false);
        }

        private void btnFindAllCorPeak_Click(object sender, EventArgs e)
        {
            if(!_allFbList.Any()) return;
            _allCorPeakList = new List<int>(_allFbList.Count);
            var sg = new SeqGen(_seqGen);
            if (numCorStart.Value > numCorEnd.Value)
            {
                var t = numCorStart.Value;
                numCorStart.Value = numCorEnd.Value;
                numCorEnd.Value = t;
            }
            int start = (int)numCorStart.Value - 1;
            int end = (int)numCorEnd.Value - 1;

            Stopwatch sw = new Stopwatch();
            


            if (cmbCorrelationMethod.SelectedIndex != 2)
            {
               if( MessageBox.Show("Данная операция отключена",
                    "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information) != DialogResult.Ignore) return;

                if (cmbCorrelationMethod.SelectedIndex == 0)
                {
                    var sp = new SearchPeak(
                        sg,
                        1,
                        1,
                        double.Parse(txtTimeConstant.Text.Replace(',', '.'), new CultureInfo("en-US")),
                        double.Parse(txtDnl.Text.Replace(',', '.'), new CultureInfo("en-US")),
                        cmbPowNl.SelectedIndex + 2,
                        true
                    );

                    sw.Start();
                    foreach (var fb in _allFbList)
                    {
                        sg.Feedback = fb;
                        sp.Calculate();

                        var i = 0;
                        var oldMv = double.MinValue;
                        var res = 0;

                        var fSt = (start+ DiscreteInMinPulse-1) / DiscreteInMinPulse+1;
                        var fE = end / DiscreteInMinPulse;

                        foreach (var val in sp.ResponseNL)
                        {
                            if (fSt <= i && i <= fE && val > oldMv) //Добавить диапазон
                            {
                                oldMv = val;
                                res = i;
                            }
                            i++;
                        }

                        res *= DiscreteInMinPulse;
                        res -= DiscreteInMinPulse - 1;
                        res = Math.Max(res, start);
                        res = Math.Min(res, end);
                        _allCorPeakList.Add(res);
                    }
                }
                else
                return;
            }
            else
            {



                var ct = sg.Period * 1L * DiscreteInMinPulse;
                ct *= ct * _allFbList.Count * (int) numCorrelationPeriods.Value;

                if (LongTimeMessageNo(ct)) return;


                var sp = new PrecisionSearchPeak(
                    sg,
                    DiscreteInMinPulse,
                    (int) numCorrelationPeriods.Value,
                    double.Parse(txtTimeConstant.Text.Replace(',', '.'), new CultureInfo("en-US")),
                    double.Parse(txtDnl.Text.Replace(',', '.'), new CultureInfo("en-US")),
                    cmbPowNl.SelectedIndex + 2
                );

                sw.Start();
                foreach (var fb in _allFbList)
                {
                    sg.Feedback = fb;
                    sp.Calculate();

                    var i = 0;
                    var oldMv = double.MinValue;
                    var res = 0;

                    foreach (var val in sp.CorrelationNL.Skip(sp.OnePer).Take(sp.OnePer))
                    {
                        if (start <= i && i <= end && (double) val > oldMv) //Добавить диапазон
                        {
                            oldMv = (double) val;
                            res = i;
                        }
                        i++;
                    }
                    _allCorPeakList.Add(res);
                }
            }
            sw.Stop();
            lblTime.Text = sw.ElapsedMilliseconds.ToString();

            UpdateFeedbacksList();
        }

        private void btnBuildGraphics_Click(object sender, EventArgs e)
        {
            if (!_seqGen.IsValid) return;
            var param = new List<IEnumerable<double>>(6);
            long ms = 0;
            Stopwatch sw = new Stopwatch();

            switch (cmbCorrelationMethod.SelectedIndex)
            {
                case 0:
                {
                    var sp = new SearchPeak(
                        _seqGen,
                        1,
                        1,
                        double.Parse(txtTimeConstant.Text.Replace(',', '.'), new CultureInfo("en-US")),
                        double.Parse(txtDnl.Text.Replace(',', '.'), new CultureInfo("en-US")),
                        cmbPowNl.SelectedIndex + 2,
                        true
                    );

                    sw.Start();
                    sp.Calculate();
                    sw.Stop();
                    ms = sw.ElapsedMilliseconds;

                    param.Add(sp.Mls.Select(Convert.ToDouble));
                    param.Add(new List<double>());
                    param.Add(new List<double>());
                    param.Add(new List<double>());
                    param.Add(sp.ResponseNL.Select(Convert.ToDouble));
                }
                    break;
                case 1:
                {
                    var sp = new SearchPeak(
                        _seqGen,
                        DiscreteInMinPulse,
                        (int) numCorrelationPeriods.Value,
                        double.Parse(txtTimeConstant.Text.Replace(',', '.'), new CultureInfo("en-US")),
                        double.Parse(txtDnl.Text.Replace(',', '.'), new CultureInfo("en-US")),
                        cmbPowNl.SelectedIndex + 2
                    );

                    sw.Start();
                    sp.Calculate();
                    sw.Stop();
                    ms = sw.ElapsedMilliseconds;

                    param.Add(sp.Mls.Select(Convert.ToDouble));
                    param.Add(sp.ResponseE.Select(Convert.ToDouble));
                    param.Add(sp.ResponseNL.Select(Convert.ToDouble));
                    param.Add(sp.CorrelationE.Select(Convert.ToDouble));
                    param.Add(sp.CorrelationNL.Select(Convert.ToDouble));
                    param.Add(param[4].Take(sp.OnePer).Zip(param[3], (x, y) => x - y));
                    param.Add(param[3].Take(sp.OnePer));
                    param.Add(param[4].Take(sp.OnePer));
                    }
                    break;
                case 2:
                case 3:
                case 4:
                {
                    var sp = new PrecisionSearchPeak(
                        _seqGen,
                        DiscreteInMinPulse,
                        (int) numCorrelationPeriods.Value,
                        double.Parse(txtTimeConstant.Text.Replace(',', '.'), new CultureInfo("en-US")),
                        double.Parse(txtDnl.Text.Replace(',', '.'), new CultureInfo("en-US")),
                        cmbPowNl.SelectedIndex + 2
                    );
                    var ct = sp.N * 1L * sp.OnePer;
                    if (LongTimeMessageNo(ct)) return;

                    sw.Start();
                    sp.Calculate();
                    sw.Stop();
                    ms = sw.ElapsedMilliseconds;

                    param.Add(sp.Mls.Select(Convert.ToDouble));
                    param.Add(sp.ResponseE.Select(Convert.ToDouble));
                    param.Add(sp.ResponseNL.Select(Convert.ToDouble));
                    param.Add(sp.CorrelationE.Select(Convert.ToDouble));
                    param.Add(sp.CorrelationNL.Select(Convert.ToDouble));
                    param.Add(sp.SubCorNlCorE().Skip(sp.OnePer).Take(sp.OnePer).Select(Convert.ToDouble));
                    param.Add(param[3].Skip(sp.OnePer).Take(sp.OnePer));
                    param.Add(param[4].Skip(sp.OnePer).Take(sp.OnePer));

                        if (cmbCorrelationMethod.SelectedIndex > 2)
                    {
                        SearchPeak spf;
                         param[1] = new List<double>();
                        param[2] = new List<double>();
                        param[3] = new List<double>();
                        param[5] = new List<double>();
                        param[6] = new List<double>();
                        

                            switch (cmbCorrelationMethod.SelectedIndex)
                        {
                            case 3:
                            {
                                spf = new SearchPeak(
                                    _seqGen,
                                    DiscreteInMinPulse,
                                    (int) numCorrelationPeriods.Value,
                                    double.Parse(txtTimeConstant.Text.Replace(',', '.'), new CultureInfo("en-US")),
                                    double.Parse(txtDnl.Text.Replace(',', '.'), new CultureInfo("en-US")),
                                    cmbPowNl.SelectedIndex + 2
                                );

                                sw.Start();
                                spf.Calculate();
                                sw.Stop();
                                ms += sw.ElapsedMilliseconds;

                                param.Add(spf.CorrelationNL.Select(Convert.ToDouble));
                                param.Add(param[4].Skip(sp.OnePer).Zip(param[3], (x, y) => y - x));
                            }
                                break;
                            case 4:
                            {
                                spf = new SearchPeak(
                                    _seqGen,
                                    1,
                                    1,
                                    double.Parse(txtTimeConstant.Text.Replace(',', '.'), new CultureInfo("en-US")) /
                                    DiscreteInMinPulse,
                                    double.Parse(txtDnl.Text.Replace(',', '.'), new CultureInfo("en-US")),
                                    cmbPowNl.SelectedIndex + 2,
                                    true
                                );

                                sw.Start();
                                spf.Calculate();
                                sw.Stop();
                                ms += sw.ElapsedMilliseconds;

                                param.Add(spf.ResponseNL.Select(Convert.ToDouble));
                                var d = DiscreteInMinPulse;
                                var a = param[4].Skip(sp.OnePer).Take(sp.OnePer).ToList();
                                var b = param[3].ToList();
                                for (int i = 0; i < a.Count; i++)
                                {
                                    a[i] = b[i / d] - a[i];
                                }
                                param.Add(a);
                            }
                                break;
                        }
                    }
                }
                    break;
            }

            lblTime.Text = ms.ToString();
            ViewForm vf = new ViewForm(param);
            vf.Show();
            vf.Activate();
        }



        private void numSaveStart_ValueChanged(object sender, EventArgs e)
        {
            if (!((Control)sender).Focused || !_allFbList.Any()) return;
            numSaveLen.Maximum = _allFbList.Count - numSaveStart.Value + 1;
        }
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            var format = cmbFormatView.SelectedIndex;
            int start = (int)numSaveStart.Value - 1;
            int end = start + (int)numSaveLen.Value;
            if (format < 0 || end>_allFbList.Count) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохранение списка обратных связей";
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            sfd.FileName = $"{_seqGen.Nbits}bit";
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            StringBuilder sb = new StringBuilder(txtAllFeedbacksList.Text.Length + 60);
            if (format < 3)
            {
                SbAppendVal(sb, format, (int)numSaveLen.Value);
                sb.AppendLine();
                SbAppendVal(sb, format, (int)numSaveRepeat.Value);
                sb.AppendLine();
            }
            for (int i = start; i < end; i++)
            {
                SbAppendVal(sb, format, _allFbList[i]);
                if (_allCorPeakList.Count == _allFbList.Count && format < 3)
                {
                    sb.Append(' ');
                    SbAppendVal(sb, format, _allCorPeakList[i] + 1);
                }
                sb.AppendLine();
            }
            using (StreamWriter file = new StreamWriter(sfd.FileName))
            {
                file.Write(sb.ToString());
            }
        }
    }
}
