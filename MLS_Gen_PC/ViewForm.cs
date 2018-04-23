using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MLS_Gen_PC
{
    public partial class ViewForm : Form
    {
        private readonly List<IEnumerable<double>> _vDataList;
        public ViewForm(List<IEnumerable<double>> vDataList)
        {
            _vDataList = vDataList;
            InitializeComponent();
        }

        private List<double> ChartData { get; set; }

        private const int MaxPoints = 50000;
        private Axis AxisX { get; set; }
        private Axis AxisY { get; set; }
        private Point StartSelect { get; set; }
        private MouseButtons SelectButton { get; set; }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!((Control)sender).Focused) return;
            int sel = cmbChartType.SelectedIndex;
            if (sel < 0 || sel >= _vDataList.Count || !_vDataList[sel].Any()) return;

            if (lblChartType.Text == "0")
            {

            }

            if (sel == 0) chart.Series[0].ChartType = SeriesChartType.StepLine;
            else if (chart.Series[0].ChartType != SeriesChartType.Line)
                chart.Series[0].ChartType = SeriesChartType.Line;

            ChartData = _vDataList[sel].ToList();
            lblChartType.Text = cmbChartType.SelectedItem.ToString();
            hScrollChart_ValueChanged(null, null);
        }

        private void hScrollChart_ValueChanged(object sender, EventArgs e)
        {
            //if (sender != null && !((Control) sender).Focused) return;
            int n = ChartData.Count;
            int v = 0;
            int start = 0;
            int end = n;
            bool isScroll = n > MaxPoints * 2;
            hScrollChart.Enabled = isScroll;
            if (isScroll)
            {
                hScrollChart.Maximum = n * 2 / MaxPoints;
                v = hScrollChart.Value;
                start = v * MaxPoints / 2;
                end = Math.Min(start + MaxPoints, n);
            }
            lblScrollPos.Text = v.ToString();
            chart.Series[0].Points.Clear();
            for (int i = start; i < end; i++)
            {
                chart.Series[0].Points.AddXY(i + 1, ChartData[i]);
            }
        }

        public void SetText(string s)
        {
            richTextBox1.Text = s;
        }


        private void ViewForm_Load(object sender, EventArgs e)
        {
           // cmbChartType.SelectedIndex = 0;
            // SetData();
            SelectButton = MouseButtons.None;

            AxisX = chart.ChartAreas[0].AxisX;
            AxisY = chart.ChartAreas[0].AxisY;
            AxisX.LabelStyle.Format = "F0";
           // AxisY.LabelStyle.Format = "F0";
            AxisX.ScrollBar.Enabled = false;
            AxisY.ScrollBar.Enabled = false;

            chart.Series[0].IsXValueIndexed = true;

            //chart1.Series[0].XValueType = ChartValueType.Int32;

            //chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            //chart1.ChartAreas[0].CursorX.SelectionColor = Color.Transparent;
            //chart1.ChartAreas[0].CursorY.SelectionColor = Color.Transparent;
            //chart1.ChartAreas[0].CursorX.LineDashStyle = ChartDashStyle.Dash;

            //  chart1.MouseMove += OnChartMouseMove;
            chart.MouseDown += OnChartMouseDown;
            chart.MouseUp += OnChartMouseUp;
        }

       
        private void OnChartMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                SelectButton = e.Button;
                StartSelect = new Point(e.X, e.Y);
            }
        }

        private void OnChartMouseUp(object sender, MouseEventArgs e)
        {
            if (SelectButton == MouseButtons.None) return;
 
            HitTestResult htr = chart.HitTest(e.X, e.Y);
            if(htr.ChartElementType == ChartElementType.Nothing) return;

            var mousedx = e.X - StartSelect.X;
            var mousedy = e.Y - StartSelect.Y;
            var x = AxisX.PixelPositionToValue(StartSelect.X);
            var y = AxisY.PixelPositionToValue(e.Y);
            var dx = AxisX.PixelPositionToValue(e.X) - x;
            var dy = AxisY.PixelPositionToValue(StartSelect.Y) - y;

            if (SelectButton == MouseButtons.Left)
            {
                if (mousedx > 0 && mousedy > 0)
                {
                    AxisX.ScaleView.Zoom(x,x+dx);
                    AxisY.ScaleView.Zoom(y,y+dy);
                    
                }
                else if (mousedx < 0 && mousedy < 0)
                {
                    var szx = AxisX.ScaleView.ViewMaximum - AxisX.ScaleView.ViewMinimum;
                    var szy = AxisY.ScaleView.ViewMaximum - AxisY.ScaleView.ViewMinimum;
                    dx = szx * szx / -dx;
                    dy = szy * szy / -dy;
                    x = AxisX.ScaleView.Position+szx/2-dx/2;
                    y = AxisY.ScaleView.Position+szy/2-dy/2;
                    AxisX.ScaleView.Zoom(x, x+dx);
                    AxisY.ScaleView.Zoom(y, y+dy);
                }
                else
                {
                    AxisX.ScaleView.ZoomReset();
                    AxisY.ScaleView.ZoomReset();
                }
            }
            if (SelectButton == MouseButtons.Right)
            {
                AxisX.ScaleView.Scroll(AxisX.ScaleView.Position - dx);
                AxisY.ScaleView.Scroll(AxisY.ScaleView.Position + dy);
            }
            SelectButton = MouseButtons.None;
        }

        private void OnChartMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void btnFindMax_Click(object sender, EventArgs e)
        {
            int n = ChartData.Count;
            if (n == 0) return;
            int startI, endI;
            if (int.TryParse(txtFindMaxStartIndex.Text, out startI) && int.TryParse(txtFindMaxEndIndex.Text, out endI))
            {
                if (startI > endI)
                {
                    var t = startI;
                    startI = endI;
                    endI = startI;
                }
                if (startI < 1) startI = 1;
                if (endI > n) endI = n;

                int maxI = startI - 1;
                for (int i = startI; i < endI; i++)
                {
                    if (ChartData[i].CompareTo(ChartData[maxI]) > 0) maxI = i;
                }
                SetText((maxI + 1).ToString());
            }
        }

      
    }
}
