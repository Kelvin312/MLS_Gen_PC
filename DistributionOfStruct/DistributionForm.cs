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
    }
}
