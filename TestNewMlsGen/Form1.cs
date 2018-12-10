using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestNewMlsGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeqGenValidator sgv = new SeqGenValidator(1<<((int)numericUpDown1.Value-1));
            while (!sgv.Validate())
            {
                sgv.Feedback++;
            }
            var fbl = sgv.CalculateDecimatMls();
            textBox1.Text = "";
            foreach (var fb in fbl)
            {
                textBox1.AppendText($"{fb:X8}\r\n");
            }
        }
    }
}
