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

namespace DistributionOfStruct
{
    public partial class DistributionForm : Form
    {
        public DistributionForm()
        {
            InitializeComponent();
            _myChart = new MyChart(chartSurface);
        }

        private MyChart _myChart;
        

        private void DistributionForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var nBits = (int)numBitCapacityMls.Value;
            var a = 0;
            var b = 0;


            var mlsBuilder = new MaxLenSequenceBuilder(nBits);
            _feedbacksDistribution = new List<List<int>>(mlsBuilder.Period);
            for (int j = 0; j < mlsBuilder.Period; j++)
            {
                _feedbacksDistribution.Add(new List<int>());
            }

            mlsBuilder.CreateNextMaxLenSequence();


            var si = 3;
            var i = si;
                foreach (var val in mlsBuilder.Correlations.Skip(si-1))
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
            CreateGraph();

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
                    fbStr+=$" 0x{fb:X5}";
                }
                if (fbList.Count > 1)
                {
                    richTextBox1.AppendText($"{ind}:"+fbStr+"\r\n");
                }

                _myChart.SeriesDataPoints.Add(new DataPoint(ind,fbList.Count) {ToolTip = fbStr });
                ++ind;
            }

            
        }


    }
}
