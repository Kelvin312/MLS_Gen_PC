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
            textBox1.Text = "";
            SeqGenValidator sgv = new SeqGenValidator(1<<((int)numericUpDown1.Value-1));
            while (!sgv.Validate())
            {
                sgv.Feedback++;
            }
            var fbl = sgv.CalculateDecimatMls();
            fbl.Add(new KeyValuePair<int, int>(sgv.Feedback, 1));
            fbl.Sort((x, y) => x.Key.CompareTo(y.Key));
           StringBuilder sb = new StringBuilder(fbl.Count);

            foreach (var fb in fbl)
            {
                sb.AppendFormat("0x{0:X8}\r\n", fb.Key, fb.Value);
            }
            textBox1.Text = sb.ToString();
        }
    }
}
