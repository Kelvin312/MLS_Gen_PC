using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            mlsBuilder.CreateNextMaxLenSequence();
            _myChart.SeriesPoints = mlsBuilder.Correlations;
           // while (mlsBuilder.CreateNextMaxLenSequence())
            {
                var i = 3;
                foreach (var val in mlsBuilder.Correlations.Skip(2))
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
            }
            numMeasurementAreaStart.Value = a;
            numMeasurementAreaEnd.Value = b;
        }
    }
}
