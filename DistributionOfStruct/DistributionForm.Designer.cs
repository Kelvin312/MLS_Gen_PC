namespace DistributionOfStruct
{
    partial class DistributionForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributionForm));
            this.chartSurface = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTypeNonlinearity = new System.Windows.Forms.ComboBox();
            this.numMeasurementAreaEnd = new System.Windows.Forms.NumericUpDown();
            this.numMeasurementAreaStart = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaxValueNonlinearity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimeEnviron = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numNsamplesMinPulse = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numBitCapacityMls = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.chartSurface)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasurementAreaEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasurementAreaStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNsamplesMinPulse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBitCapacityMls)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSurface
            // 
            this.chartSurface.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartSurface.ChartAreas.Add(chartArea1);
            this.chartSurface.Location = new System.Drawing.Point(8, 19);
            this.chartSurface.Name = "chartSurface";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chartSurface.Series.Add(series1);
            this.chartSurface.Size = new System.Drawing.Size(801, 482);
            this.chartSurface.TabIndex = 0;
            this.chartSurface.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chartSurface);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(815, 507);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnRun);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbTypeNonlinearity);
            this.groupBox2.Controls.Add(this.numMeasurementAreaEnd);
            this.groupBox2.Controls.Add(this.numMeasurementAreaStart);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMaxValueNonlinearity);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTimeEnviron);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numNsamplesMinPulse);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numBitCapacityMls);
            this.groupBox2.Location = new System.Drawing.Point(833, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 507);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(203, 201);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 18;
            this.btnRun.Text = "Построить";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.Location = new System.Drawing.Point(9, 261);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(269, 240);
            this.richTextBox1.TabIndex = 17;
            this.richTextBox1.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Конечная дискрета обл. измер.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Начальная дискрета обл. измер.";
            // 
            // cmbTypeNonlinearity
            // 
            this.cmbTypeNonlinearity.FormattingEnabled = true;
            this.cmbTypeNonlinearity.Items.AddRange(new object[] {
            "X^2",
            "X^3",
            "X^4",
            "X^5",
            "X^6",
            "X^7"});
            this.cmbTypeNonlinearity.Location = new System.Drawing.Point(204, 122);
            this.cmbTypeNonlinearity.Name = "cmbTypeNonlinearity";
            this.cmbTypeNonlinearity.Size = new System.Drawing.Size(74, 21);
            this.cmbTypeNonlinearity.TabIndex = 14;
            this.cmbTypeNonlinearity.Text = "X^2";
            // 
            // numMeasurementAreaEnd
            // 
            this.numMeasurementAreaEnd.Location = new System.Drawing.Point(204, 175);
            this.numMeasurementAreaEnd.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMeasurementAreaEnd.Name = "numMeasurementAreaEnd";
            this.numMeasurementAreaEnd.Size = new System.Drawing.Size(74, 20);
            this.numMeasurementAreaEnd.TabIndex = 13;
            // 
            // numMeasurementAreaStart
            // 
            this.numMeasurementAreaStart.Location = new System.Drawing.Point(204, 149);
            this.numMeasurementAreaStart.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMeasurementAreaStart.Name = "numMeasurementAreaStart";
            this.numMeasurementAreaStart.Size = new System.Drawing.Size(74, 20);
            this.numMeasurementAreaStart.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Тип нелинейности";
            // 
            // txtMaxValueNonlinearity
            // 
            this.txtMaxValueNonlinearity.Location = new System.Drawing.Point(204, 97);
            this.txtMaxValueNonlinearity.Name = "txtMaxValueNonlinearity";
            this.txtMaxValueNonlinearity.Size = new System.Drawing.Size(74, 20);
            this.txtMaxValueNonlinearity.TabIndex = 10;
            this.txtMaxValueNonlinearity.Text = "0.4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Макс. знач. нелинейности";
            // 
            // txtTimeEnviron
            // 
            this.txtTimeEnviron.Location = new System.Drawing.Point(204, 71);
            this.txtTimeEnviron.Name = "txtTimeEnviron";
            this.txtTimeEnviron.Size = new System.Drawing.Size(74, 20);
            this.txtTimeEnviron.TabIndex = 8;
            this.txtTimeEnviron.Text = "0.8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Постоянная времени среды";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Кол-во дискрет в мин. импульсе";
            // 
            // numNsamplesMinPulse
            // 
            this.numNsamplesMinPulse.Location = new System.Drawing.Point(204, 45);
            this.numNsamplesMinPulse.Name = "numNsamplesMinPulse";
            this.numNsamplesMinPulse.Size = new System.Drawing.Size(74, 20);
            this.numNsamplesMinPulse.TabIndex = 2;
            this.numNsamplesMinPulse.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Разрядность М-последоват.";
            // 
            // numBitCapacityMls
            // 
            this.numBitCapacityMls.Location = new System.Drawing.Point(204, 19);
            this.numBitCapacityMls.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numBitCapacityMls.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numBitCapacityMls.Name = "numBitCapacityMls";
            this.numBitCapacityMls.Size = new System.Drawing.Size(74, 20);
            this.numBitCapacityMls.TabIndex = 0;
            this.numBitCapacityMls.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // DistributionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 531);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DistributionForm";
            this.Text = "Распределение пиков";
            this.Load += new System.EventHandler(this.DistributionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSurface)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasurementAreaEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasurementAreaStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNsamplesMinPulse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBitCapacityMls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSurface;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numBitCapacityMls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numNsamplesMinPulse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimeEnviron;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaxValueNonlinearity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTypeNonlinearity;
        private System.Windows.Forms.NumericUpDown numMeasurementAreaEnd;
        private System.Windows.Forms.NumericUpDown numMeasurementAreaStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnRun;
    }
}

