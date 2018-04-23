namespace MLS_Gen_PC
{
    partial class ViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.hScrollChart = new System.Windows.Forms.HScrollBar();
            this.cmbChartType = new System.Windows.Forms.ComboBox();
            this.lblChartType = new System.Windows.Forms.Label();
            this.lblScrollPos = new System.Windows.Forms.Label();
            this.btnFindMax = new System.Windows.Forms.Button();
            this.txtFindMaxStartIndex = new System.Windows.Forms.TextBox();
            this.txtFindMaxEndIndex = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            this.chart.Location = new System.Drawing.Point(9, 9);
            this.chart.Margin = new System.Windows.Forms.Padding(0);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series1";
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(827, 394);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(870, 14);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(121, 93);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // hScrollChart
            // 
            this.hScrollChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollChart.Enabled = false;
            this.hScrollChart.LargeChange = 2;
            this.hScrollChart.Location = new System.Drawing.Point(870, 383);
            this.hScrollChart.Name = "hScrollChart";
            this.hScrollChart.Size = new System.Drawing.Size(121, 17);
            this.hScrollChart.TabIndex = 2;
            this.hScrollChart.ValueChanged += new System.EventHandler(this.hScrollChart_ValueChanged);
            // 
            // cmbChartType
            // 
            this.cmbChartType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.Items.AddRange(new object[] {
            "М-последовательность",
            "Отклик среды",
            "Нелинейность",
            "Кор-я Отклик ср. ",
            "Кор-я Нелинейн.",
            "Кор-я Нл. - Кор-я Отк. ср. ",
            "Кор-я Отклик ср.  1п.",
            "Кор-я Нелинейн. 1п.",
            "Кор-я Нелинейн. FFT",
            "Сравнение NL FFT - NL"});
            this.cmbChartType.Location = new System.Drawing.Point(839, 274);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(160, 21);
            this.cmbChartType.TabIndex = 3;
            this.cmbChartType.SelectedIndexChanged += new System.EventHandler(this.cmbChartType_SelectedIndexChanged);
            // 
            // lblChartType
            // 
            this.lblChartType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChartType.AutoSize = true;
            this.lblChartType.Location = new System.Drawing.Point(869, 337);
            this.lblChartType.Name = "lblChartType";
            this.lblChartType.Size = new System.Drawing.Size(13, 13);
            this.lblChartType.TabIndex = 5;
            this.lblChartType.Text = "0";
            // 
            // lblScrollPos
            // 
            this.lblScrollPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScrollPos.AutoSize = true;
            this.lblScrollPos.Location = new System.Drawing.Point(869, 360);
            this.lblScrollPos.Name = "lblScrollPos";
            this.lblScrollPos.Size = new System.Drawing.Size(13, 13);
            this.lblScrollPos.TabIndex = 6;
            this.lblScrollPos.Text = "0";
            // 
            // btnFindMax
            // 
            this.btnFindMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindMax.Enabled = false;
            this.btnFindMax.Location = new System.Drawing.Point(893, 139);
            this.btnFindMax.Name = "btnFindMax";
            this.btnFindMax.Size = new System.Drawing.Size(75, 23);
            this.btnFindMax.TabIndex = 7;
            this.btnFindMax.Text = "Максимум";
            this.btnFindMax.UseVisualStyleBackColor = true;
            this.btnFindMax.Click += new System.EventHandler(this.btnFindMax_Click);
            // 
            // txtFindMaxStartIndex
            // 
            this.txtFindMaxStartIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFindMaxStartIndex.Location = new System.Drawing.Point(870, 113);
            this.txtFindMaxStartIndex.Name = "txtFindMaxStartIndex";
            this.txtFindMaxStartIndex.Size = new System.Drawing.Size(40, 20);
            this.txtFindMaxStartIndex.TabIndex = 8;
            this.txtFindMaxStartIndex.Text = "0";
            // 
            // txtFindMaxEndIndex
            // 
            this.txtFindMaxEndIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFindMaxEndIndex.Location = new System.Drawing.Point(949, 113);
            this.txtFindMaxEndIndex.Name = "txtFindMaxEndIndex";
            this.txtFindMaxEndIndex.Size = new System.Drawing.Size(40, 20);
            this.txtFindMaxEndIndex.TabIndex = 9;
            this.txtFindMaxEndIndex.Text = "2047";
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 412);
            this.Controls.Add(this.txtFindMaxEndIndex);
            this.Controls.Add(this.txtFindMaxStartIndex);
            this.Controls.Add(this.btnFindMax);
            this.Controls.Add(this.lblScrollPos);
            this.Controls.Add(this.lblChartType);
            this.Controls.Add(this.cmbChartType);
            this.Controls.Add(this.hScrollChart);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.chart);
            this.Name = "ViewForm";
            this.Text = "ViewForm";
            this.Load += new System.EventHandler(this.ViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.HScrollBar hScrollChart;
        private System.Windows.Forms.ComboBox cmbChartType;
        private System.Windows.Forms.Label lblChartType;
        private System.Windows.Forms.Label lblScrollPos;
        private System.Windows.Forms.Button btnFindMax;
        private System.Windows.Forms.TextBox txtFindMaxStartIndex;
        private System.Windows.Forms.TextBox txtFindMaxEndIndex;
    }
}