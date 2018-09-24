using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DistributionOfStruct
{
    public partial class DistributionForm : Form
    {
        public DistributionForm()
        {
            InitializeComponent();
            _myChart = new MyChart(chartSurface);

            btnSaveChart.Enabled = false;

            cmbChartType.Items.AddRange(Enum.GetValues(typeof(SeriesChartType)).Cast<SeriesChartType>().Cast<object>().ToArray());
            cmbChartType.SelectedItem = _myChart.SeriesType;
            cmbChartType.SelectedIndexChanged += CmbChartType_SelectedIndexChanged; 
        }

        private void CmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmbSender = sender as ComboBox;
            if (!(cmbSender?.SelectedItem is SeriesChartType)) return;
            _myChart.SeriesType = (SeriesChartType)cmbSender.SelectedItem;
        }

        private readonly MyChart _myChart;
        

        private void DistributionForm_Load(object sender, EventArgs e)
        {
            
        }

        private List<KeyValuePair<int,int>> _allFeedbackList = new List<KeyValuePair<int, int>>();
        private void Run(int nBits)
        {
            var a = 0;
            var b = 0;


            var mlsBuilder = new MaxLenSequenceBuilder(nBits);
            _feedbacksDistribution = new List<List<int>>(mlsBuilder.Period);
            _allFeedbackList = new List<KeyValuePair<int, int>>( mlsBuilder.GetMaxFeedbackCount());

            for (int j = 0; j < mlsBuilder.Period; j++)
            {
                _feedbacksDistribution.Add(new List<int>());
            }

            mlsBuilder.CreateNextMaxLenSequence();


            var si = 3;
            var i = si;
            foreach (var val in mlsBuilder.Correlations.Skip(si - 1))
            {
                if (val < 0)
                {
                    a = i;
                    break;
                }
                ++i;
            }
            i = mlsBuilder.Period;
            foreach (var val in mlsBuilder.Correlations.Reverse())
            {
                if (val < 0)
                {
                    b = i;
                    break;
                }
                --i;
            }

            numMeasurementAreaStart.Value = a;
            numMeasurementAreaEnd.Value = b;


            //chartSurface.Series[0].ChartType = SeriesChartType.Line;
            //  _myChart.SeriesPoints = mlsBuilder.Correlations;
            do
            {
                
                CreateDistribution(mlsBuilder, a - 1, b - a + 1);
            } while (mlsBuilder.CreateNextMaxLenSequence());
        }

       

        private void btnRun_Click(object sender, EventArgs e)
        {
            var nBits = (int)numBitCapacityMls.Value;
           Run(nBits);
            CreateGraph();
            btnSaveChart.Enabled = true;
        }

        private List<List<int>> _feedbacksDistribution = new List<List<int>>();

        public void CreateDistribution(MaxLenSequenceBuilder mlsBuilder, int start, int len)
        {
            var ind = start;
            var maxVal = 0.0;
            var maxInd = 0;
            foreach (var val in mlsBuilder.Correlations.Skip(start).Take(len))
            {
                if (val > maxVal)
                {
                    maxVal = val;
                    maxInd = ind;
                }
                ++ind;
            }
            _feedbacksDistribution[maxInd].Add(mlsBuilder.Feedback);

            _allFeedbackList.Add(new KeyValuePair<int, int>(mlsBuilder.Feedback, maxInd));
        }

        public void CreateGraph()
        {
            _myChart.SeriesDataPoints.Clear();
            richTextBox1.Clear();

            var ind = 1;

            foreach (var fbList in _feedbacksDistribution)
            {
                var fbStr = "";
                foreach (var fb in fbList)
                {
                    fbStr += $"-[{fb}](";
                    var dot = false;
                    for (var i = 0; i < 24; i++)
                    {
                        if (((1 << i) & fb) != 0)
                        {
                            if (dot) fbStr += ',';
                            fbStr += $"{i + 1}";
                            dot = true;
                        }
                    }
                    fbStr += ")";
                }
                if (fbList.Count > 1)
                {
                    richTextBox1.AppendText($"{ind}"+fbStr+"\r\n");
                }

                _myChart.SeriesDataPoints.Add(new DataPoint(ind,fbList.Count) {ToolTip = fbStr });
                ++ind;
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            // for (var nBits = 11; nBits <= (int) numericUpDown1.Value; nBits++)
            var nBits = (int)numBitCapacityMls.Value;

            {
                Run(nBits);
                var h = 0;
                foreach (var fbList in _feedbacksDistribution)
                {
                    if (fbList.Count > 1)
                    {
                        for (var x = 0; x < fbList.Count - 1; x++)
                            _allFeedbackList.Remove(new KeyValuePair<int,int>(fbList[x],h));

                    }
                    ++h;
                }

                sb.AppendLine($"{_allFeedbackList.Count}");
                foreach (var fb in _allFeedbackList)
                {
                    sb.AppendLine($"{fb.Key} {fb.Value+1}");
                }
            }

            using (var file = new StreamWriter($"{nBits}bit.txt"))
            {
                file.Write(sb.ToString());
            }
        }

        private void btnSaveChart_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("X \tY \tZ\r\n");
            foreach (var dp in _myChart.SeriesDataPoints)
            {
                sb.AppendFormat("{0} \t{1} \t{2}\r\n",dp.XValue,dp.YValues[0],dp.ToolTip);
            }
            using (var file = new StreamWriter($"chartData{(int)numBitCapacityMls.Value}bit.txt"))
            {
                file.Write(sb.ToString());
            }

        }

        private void numBitCapacityMls_ValueChanged(object sender, EventArgs e)
        {
            btnSaveChart.Enabled = false;
        }

        private void cbForPublication_CheckedChanged(object sender, EventArgs e)
        {
            _myChart.IsPublication = cbForPublication.Checked;
        }
    }
}
