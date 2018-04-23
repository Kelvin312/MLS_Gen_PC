namespace MLS_Gen_PC
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numDiscreteInMinPulse = new System.Windows.Forms.NumericUpDown();
            this.numSaveRepeat = new System.Windows.Forms.NumericUpDown();
            this.panelFeedbacks = new System.Windows.Forms.Panel();
            this.lblSingleFeedbackIsMls = new System.Windows.Forms.Label();
            this.grbSaveToFile = new System.Windows.Forms.GroupBox();
            this.numSaveLen = new System.Windows.Forms.NumericUpDown();
            this.numSaveStart = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnFindAllCorPeak = new System.Windows.Forms.Button();
            this.btnBuildGraphics = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFindNextFeedback = new System.Windows.Forms.Button();
            this.txtSingleFeedbackHex = new System.Windows.Forms.TextBox();
            this.grbMultipleFeedbacks = new System.Windows.Forms.GroupBox();
            this.txtAllFeedbacksList = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFormatView = new System.Windows.Forms.ComboBox();
            this.btnFindAllFeedback = new System.Windows.Forms.Button();
            this.lblAllFeedbackCount = new System.Windows.Forms.Label();
            this.grbSingleFeedback = new System.Windows.Forms.GroupBox();
            this.txtSingleFeedbackIsMls = new System.Windows.Forms.TextBox();
            this.txtSingleFeedbackDec = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grbCorrelation = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbCorrelationMethod = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDnl = new System.Windows.Forms.TextBox();
            this.txtTimeConstant = new System.Windows.Forms.TextBox();
            this.cmbPowNl = new System.Windows.Forms.ComboBox();
            this.numCorrelationPeriods = new System.Windows.Forms.NumericUpDown();
            this.numCorEnd = new System.Windows.Forms.NumericUpDown();
            this.numCorStart = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grbInfo = new System.Windows.Forms.GroupBox();
            this.txtMaxFeedbackCnt = new System.Windows.Forms.TextBox();
            this.txtFeedbackPeriod = new System.Windows.Forms.TextBox();
            this.txtFeedbackNbits = new System.Windows.Forms.TextBox();
            this.lblFeedbackPeriod = new System.Windows.Forms.Label();
            this.lblFeedbackCapacity = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timChangeText = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numDiscreteInMinPulse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaveRepeat)).BeginInit();
            this.grbSaveToFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSaveLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaveStart)).BeginInit();
            this.grbMultipleFeedbacks.SuspendLayout();
            this.grbSingleFeedback.SuspendLayout();
            this.grbCorrelation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCorrelationPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCorEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCorStart)).BeginInit();
            this.grbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кол-во дискрет в мин. импульсе";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Кол-во повторов одной М-пос-ти";
            // 
            // numDiscreteInMinPulse
            // 
            this.numDiscreteInMinPulse.Location = new System.Drawing.Point(202, 97);
            this.numDiscreteInMinPulse.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numDiscreteInMinPulse.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDiscreteInMinPulse.Name = "numDiscreteInMinPulse";
            this.numDiscreteInMinPulse.Size = new System.Drawing.Size(100, 20);
            this.numDiscreteInMinPulse.TabIndex = 3;
            this.numDiscreteInMinPulse.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numDiscreteInMinPulse.ValueChanged += new System.EventHandler(this.numDiscreteInMinPulse_ValueChanged);
            // 
            // numSaveRepeat
            // 
            this.numSaveRepeat.Location = new System.Drawing.Point(202, 19);
            this.numSaveRepeat.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numSaveRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSaveRepeat.Name = "numSaveRepeat";
            this.numSaveRepeat.Size = new System.Drawing.Size(100, 20);
            this.numSaveRepeat.TabIndex = 5;
            this.numSaveRepeat.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // panelFeedbacks
            // 
            this.panelFeedbacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFeedbacks.Location = new System.Drawing.Point(9, 19);
            this.panelFeedbacks.Name = "panelFeedbacks";
            this.panelFeedbacks.Size = new System.Drawing.Size(957, 22);
            this.panelFeedbacks.TabIndex = 6;
            // 
            // lblSingleFeedbackIsMls
            // 
            this.lblSingleFeedbackIsMls.AutoSize = true;
            this.lblSingleFeedbackIsMls.Location = new System.Drawing.Point(622, 50);
            this.lblSingleFeedbackIsMls.Name = "lblSingleFeedbackIsMls";
            this.lblSingleFeedbackIsMls.Size = new System.Drawing.Size(141, 13);
            this.lblSingleFeedbackIsMls.TabIndex = 10;
            this.lblSingleFeedbackIsMls.Text = "Тип последовательности: ";
            // 
            // grbSaveToFile
            // 
            this.grbSaveToFile.Controls.Add(this.numSaveLen);
            this.grbSaveToFile.Controls.Add(this.numSaveRepeat);
            this.grbSaveToFile.Controls.Add(this.label3);
            this.grbSaveToFile.Controls.Add(this.numSaveStart);
            this.grbSaveToFile.Controls.Add(this.label9);
            this.grbSaveToFile.Controls.Add(this.label8);
            this.grbSaveToFile.Controls.Add(this.btnSaveFile);
            this.grbSaveToFile.Location = new System.Drawing.Point(625, 298);
            this.grbSaveToFile.Name = "grbSaveToFile";
            this.grbSaveToFile.Size = new System.Drawing.Size(315, 145);
            this.grbSaveToFile.TabIndex = 13;
            this.grbSaveToFile.TabStop = false;
            this.grbSaveToFile.Text = "Параметры сохранения списка обратных связей";
            // 
            // numSaveLen
            // 
            this.numSaveLen.Location = new System.Drawing.Point(202, 71);
            this.numSaveLen.Name = "numSaveLen";
            this.numSaveLen.Size = new System.Drawing.Size(100, 20);
            this.numSaveLen.TabIndex = 9;
            // 
            // numSaveStart
            // 
            this.numSaveStart.Location = new System.Drawing.Point(202, 45);
            this.numSaveStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSaveStart.Name = "numSaveStart";
            this.numSaveStart.Size = new System.Drawing.Size(100, 20);
            this.numSaveStart.TabIndex = 8;
            this.numSaveStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSaveStart.ValueChanged += new System.EventHandler(this.numSaveStart_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Количество обратных связей";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Номер начальной обратной связи";
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Enabled = false;
            this.btnSaveFile.Location = new System.Drawing.Point(168, 98);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(134, 36);
            this.btnSaveFile.TabIndex = 3;
            this.btnSaveFile.Text = "Сохранить";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnFindAllCorPeak
            // 
            this.btnFindAllCorPeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindAllCorPeak.Enabled = false;
            this.btnFindAllCorPeak.Location = new System.Drawing.Point(457, 109);
            this.btnFindAllCorPeak.Name = "btnFindAllCorPeak";
            this.btnFindAllCorPeak.Size = new System.Drawing.Size(134, 36);
            this.btnFindAllCorPeak.TabIndex = 13;
            this.btnFindAllCorPeak.Text = "Найти все";
            this.btnFindAllCorPeak.UseVisualStyleBackColor = true;
            this.btnFindAllCorPeak.Click += new System.EventHandler(this.btnFindAllCorPeak_Click);
            // 
            // btnBuildGraphics
            // 
            this.btnBuildGraphics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildGraphics.Enabled = false;
            this.btnBuildGraphics.Location = new System.Drawing.Point(457, 161);
            this.btnBuildGraphics.Name = "btnBuildGraphics";
            this.btnBuildGraphics.Size = new System.Drawing.Size(134, 36);
            this.btnBuildGraphics.TabIndex = 12;
            this.btnBuildGraphics.Text = "Графики";
            this.btnBuildGraphics.UseVisualStyleBackColor = true;
            this.btnBuildGraphics.Click += new System.EventHandler(this.btnBuildGraphics_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "В шестнадцатеричном виде";
            // 
            // btnFindNextFeedback
            // 
            this.btnFindNextFeedback.Location = new System.Drawing.Point(9, 19);
            this.btnFindNextFeedback.Name = "btnFindNextFeedback";
            this.btnFindNextFeedback.Size = new System.Drawing.Size(134, 36);
            this.btnFindNextFeedback.TabIndex = 2;
            this.btnFindNextFeedback.Text = "Найти следующую обратную связь";
            this.btnFindNextFeedback.UseVisualStyleBackColor = true;
            this.btnFindNextFeedback.Click += new System.EventHandler(this.btnFindNextFeedback_Click);
            // 
            // txtSingleFeedbackHex
            // 
            this.txtSingleFeedbackHex.Location = new System.Drawing.Point(176, 47);
            this.txtSingleFeedbackHex.Name = "txtSingleFeedbackHex";
            this.txtSingleFeedbackHex.Size = new System.Drawing.Size(100, 20);
            this.txtSingleFeedbackHex.TabIndex = 0;
            this.txtSingleFeedbackHex.TextChanged += new System.EventHandler(this.txtSingleFeedbackHex_TextChanged);
            // 
            // grbMultipleFeedbacks
            // 
            this.grbMultipleFeedbacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grbMultipleFeedbacks.Controls.Add(this.txtAllFeedbacksList);
            this.grbMultipleFeedbacks.Controls.Add(this.label6);
            this.grbMultipleFeedbacks.Controls.Add(this.label2);
            this.grbMultipleFeedbacks.Controls.Add(this.cmbFormatView);
            this.grbMultipleFeedbacks.Controls.Add(this.btnFindNextFeedback);
            this.grbMultipleFeedbacks.Controls.Add(this.btnFindAllFeedback);
            this.grbMultipleFeedbacks.Location = new System.Drawing.Point(12, 82);
            this.grbMultipleFeedbacks.Name = "grbMultipleFeedbacks";
            this.grbMultipleFeedbacks.Size = new System.Drawing.Size(607, 210);
            this.grbMultipleFeedbacks.TabIndex = 14;
            this.grbMultipleFeedbacks.TabStop = false;
            this.grbMultipleFeedbacks.Text = "Генератор обратных связей";
            // 
            // txtAllFeedbacksList
            // 
            this.txtAllFeedbacksList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAllFeedbacksList.BackColor = System.Drawing.SystemColors.Window;
            this.txtAllFeedbacksList.Location = new System.Drawing.Point(176, 32);
            this.txtAllFeedbacksList.Name = "txtAllFeedbacksList";
            this.txtAllFeedbacksList.ReadOnly = true;
            this.txtAllFeedbacksList.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtAllFeedbacksList.Size = new System.Drawing.Size(415, 172);
            this.txtAllFeedbacksList.TabIndex = 12;
            this.txtAllFeedbacksList.Text = "";
            this.txtAllFeedbacksList.SelectionChanged += new System.EventHandler(this.txtAllFeedbacksList_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Список обратных связей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Формат вывода";
            // 
            // cmbFormatView
            // 
            this.cmbFormatView.FormattingEnabled = true;
            this.cmbFormatView.Items.AddRange(new object[] {
            "Десятичный",
            "Шестнадцатеричный",
            "Двоичный",
            "Массив",
            "Полином"});
            this.cmbFormatView.Location = new System.Drawing.Point(9, 125);
            this.cmbFormatView.Name = "cmbFormatView";
            this.cmbFormatView.Size = new System.Drawing.Size(134, 21);
            this.cmbFormatView.TabIndex = 7;
            this.cmbFormatView.SelectedIndexChanged += new System.EventHandler(this.cmbFormatView_SelectedIndexChanged);
            // 
            // btnFindAllFeedback
            // 
            this.btnFindAllFeedback.Location = new System.Drawing.Point(9, 61);
            this.btnFindAllFeedback.Name = "btnFindAllFeedback";
            this.btnFindAllFeedback.Size = new System.Drawing.Size(134, 36);
            this.btnFindAllFeedback.TabIndex = 2;
            this.btnFindAllFeedback.Text = "Найти все этой разрядности";
            this.btnFindAllFeedback.UseVisualStyleBackColor = true;
            this.btnFindAllFeedback.Click += new System.EventHandler(this.btnFindAllFeedback_Click);
            // 
            // lblAllFeedbackCount
            // 
            this.lblAllFeedbackCount.AutoSize = true;
            this.lblAllFeedbackCount.Location = new System.Drawing.Point(9, 74);
            this.lblAllFeedbackCount.Name = "lblAllFeedbackCount";
            this.lblAllFeedbackCount.Size = new System.Drawing.Size(169, 13);
            this.lblAllFeedbackCount.TabIndex = 5;
            this.lblAllFeedbackCount.Text = "Макс. кол-во обратных связей: ";
            // 
            // grbSingleFeedback
            // 
            this.grbSingleFeedback.Controls.Add(this.txtSingleFeedbackIsMls);
            this.grbSingleFeedback.Controls.Add(this.txtSingleFeedbackDec);
            this.grbSingleFeedback.Controls.Add(this.label10);
            this.grbSingleFeedback.Controls.Add(this.label4);
            this.grbSingleFeedback.Controls.Add(this.lblSingleFeedbackIsMls);
            this.grbSingleFeedback.Controls.Add(this.panelFeedbacks);
            this.grbSingleFeedback.Controls.Add(this.txtSingleFeedbackHex);
            this.grbSingleFeedback.Location = new System.Drawing.Point(12, 3);
            this.grbSingleFeedback.Name = "grbSingleFeedback";
            this.grbSingleFeedback.Size = new System.Drawing.Size(972, 73);
            this.grbSingleFeedback.TabIndex = 15;
            this.grbSingleFeedback.TabStop = false;
            this.grbSingleFeedback.Text = "Номера отводов обратной связи:";
            // 
            // txtSingleFeedbackIsMls
            // 
            this.txtSingleFeedbackIsMls.Location = new System.Drawing.Point(781, 47);
            this.txtSingleFeedbackIsMls.Name = "txtSingleFeedbackIsMls";
            this.txtSingleFeedbackIsMls.ReadOnly = true;
            this.txtSingleFeedbackIsMls.Size = new System.Drawing.Size(134, 20);
            this.txtSingleFeedbackIsMls.TabIndex = 13;
            // 
            // txtSingleFeedbackDec
            // 
            this.txtSingleFeedbackDec.Location = new System.Drawing.Point(433, 47);
            this.txtSingleFeedbackDec.Name = "txtSingleFeedbackDec";
            this.txtSingleFeedbackDec.Size = new System.Drawing.Size(100, 20);
            this.txtSingleFeedbackDec.TabIndex = 12;
            this.txtSingleFeedbackDec.TextChanged += new System.EventHandler(this.txtSingleFeedbackDec_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(323, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "В десятичном виде";
            // 
            // grbCorrelation
            // 
            this.grbCorrelation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grbCorrelation.Controls.Add(this.label15);
            this.grbCorrelation.Controls.Add(this.cmbCorrelationMethod);
            this.grbCorrelation.Controls.Add(this.label14);
            this.grbCorrelation.Controls.Add(this.txtDnl);
            this.grbCorrelation.Controls.Add(this.txtTimeConstant);
            this.grbCorrelation.Controls.Add(this.btnBuildGraphics);
            this.grbCorrelation.Controls.Add(this.btnFindAllCorPeak);
            this.grbCorrelation.Controls.Add(this.cmbPowNl);
            this.grbCorrelation.Controls.Add(this.numCorrelationPeriods);
            this.grbCorrelation.Controls.Add(this.numCorEnd);
            this.grbCorrelation.Controls.Add(this.numCorStart);
            this.grbCorrelation.Controls.Add(this.label13);
            this.grbCorrelation.Controls.Add(this.label5);
            this.grbCorrelation.Controls.Add(this.label12);
            this.grbCorrelation.Controls.Add(this.label11);
            this.grbCorrelation.Controls.Add(this.label7);
            this.grbCorrelation.Location = new System.Drawing.Point(12, 298);
            this.grbCorrelation.Name = "grbCorrelation";
            this.grbCorrelation.Size = new System.Drawing.Size(607, 206);
            this.grbCorrelation.TabIndex = 16;
            this.grbCorrelation.TabStop = false;
            this.grbCorrelation.Text = "Параметры поиска коррелляциооных пиков";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 179);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Конец поиска макс. пика";
            // 
            // cmbCorrelationMethod
            // 
            this.cmbCorrelationMethod.FormattingEnabled = true;
            this.cmbCorrelationMethod.Items.AddRange(new object[] {
            "1. Быстрый поиск кор. пиков БПФ (double)",
            "2. Построение графиков БПФ (double)",
            "3. Построение точных графиков (double)",
            "4. Сравнение методов 2 и 3",
            "5. Сравнение методов 1 и 3"});
            this.cmbCorrelationMethod.Location = new System.Drawing.Point(176, 19);
            this.cmbCorrelationMethod.Name = "cmbCorrelationMethod";
            this.cmbCorrelationMethod.Size = new System.Drawing.Size(264, 21);
            this.cmbCorrelationMethod.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Метод построения";
            // 
            // txtDnl
            // 
            this.txtDnl.Location = new System.Drawing.Point(176, 98);
            this.txtDnl.Name = "txtDnl";
            this.txtDnl.Size = new System.Drawing.Size(100, 20);
            this.txtDnl.TabIndex = 26;
            this.txtDnl.Text = "0.4";
            // 
            // txtTimeConstant
            // 
            this.txtTimeConstant.Location = new System.Drawing.Point(176, 72);
            this.txtTimeConstant.Name = "txtTimeConstant";
            this.txtTimeConstant.Size = new System.Drawing.Size(100, 20);
            this.txtTimeConstant.TabIndex = 25;
            this.txtTimeConstant.Text = "0.8";
            // 
            // cmbPowNl
            // 
            this.cmbPowNl.FormattingEnabled = true;
            this.cmbPowNl.Items.AddRange(new object[] {
            "X^2",
            "X^3",
            "X^4",
            "X^5",
            "X^6",
            "X^7"});
            this.cmbPowNl.Location = new System.Drawing.Point(176, 124);
            this.cmbPowNl.Name = "cmbPowNl";
            this.cmbPowNl.Size = new System.Drawing.Size(100, 21);
            this.cmbPowNl.TabIndex = 24;
            // 
            // numCorrelationPeriods
            // 
            this.numCorrelationPeriods.Location = new System.Drawing.Point(176, 46);
            this.numCorrelationPeriods.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numCorrelationPeriods.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCorrelationPeriods.Name = "numCorrelationPeriods";
            this.numCorrelationPeriods.Size = new System.Drawing.Size(100, 20);
            this.numCorrelationPeriods.TabIndex = 21;
            this.numCorrelationPeriods.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numCorEnd
            // 
            this.numCorEnd.Location = new System.Drawing.Point(176, 177);
            this.numCorEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCorEnd.Name = "numCorEnd";
            this.numCorEnd.Size = new System.Drawing.Size(100, 20);
            this.numCorEnd.TabIndex = 23;
            this.numCorEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numCorStart
            // 
            this.numCorStart.Location = new System.Drawing.Point(176, 151);
            this.numCorStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCorStart.Name = "numCorStart";
            this.numCorStart.Size = new System.Drawing.Size(100, 20);
            this.numCorStart.TabIndex = 22;
            this.numCorStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Количество периодов";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Начало поиска макс. пика";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Тип нелинейности";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Макс. значение нелинейности";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Постоянная времени среды";
            // 
            // grbInfo
            // 
            this.grbInfo.Controls.Add(this.txtMaxFeedbackCnt);
            this.grbInfo.Controls.Add(this.txtFeedbackPeriod);
            this.grbInfo.Controls.Add(this.txtFeedbackNbits);
            this.grbInfo.Controls.Add(this.lblFeedbackPeriod);
            this.grbInfo.Controls.Add(this.lblFeedbackCapacity);
            this.grbInfo.Controls.Add(this.lblAllFeedbackCount);
            this.grbInfo.Controls.Add(this.label1);
            this.grbInfo.Controls.Add(this.numDiscreteInMinPulse);
            this.grbInfo.Location = new System.Drawing.Point(625, 82);
            this.grbInfo.Name = "grbInfo";
            this.grbInfo.Size = new System.Drawing.Size(315, 210);
            this.grbInfo.TabIndex = 17;
            this.grbInfo.TabStop = false;
            this.grbInfo.Text = "Общие параметры М-пос-тей текущей разрядности";
            // 
            // txtMaxFeedbackCnt
            // 
            this.txtMaxFeedbackCnt.Location = new System.Drawing.Point(202, 70);
            this.txtMaxFeedbackCnt.Name = "txtMaxFeedbackCnt";
            this.txtMaxFeedbackCnt.ReadOnly = true;
            this.txtMaxFeedbackCnt.Size = new System.Drawing.Size(100, 20);
            this.txtMaxFeedbackCnt.TabIndex = 10;
            // 
            // txtFeedbackPeriod
            // 
            this.txtFeedbackPeriod.Location = new System.Drawing.Point(202, 44);
            this.txtFeedbackPeriod.Name = "txtFeedbackPeriod";
            this.txtFeedbackPeriod.ReadOnly = true;
            this.txtFeedbackPeriod.Size = new System.Drawing.Size(100, 20);
            this.txtFeedbackPeriod.TabIndex = 9;
            // 
            // txtFeedbackNbits
            // 
            this.txtFeedbackNbits.Location = new System.Drawing.Point(202, 19);
            this.txtFeedbackNbits.Name = "txtFeedbackNbits";
            this.txtFeedbackNbits.ReadOnly = true;
            this.txtFeedbackNbits.Size = new System.Drawing.Size(100, 20);
            this.txtFeedbackNbits.TabIndex = 8;
            // 
            // lblFeedbackPeriod
            // 
            this.lblFeedbackPeriod.AutoSize = true;
            this.lblFeedbackPeriod.Location = new System.Drawing.Point(9, 48);
            this.lblFeedbackPeriod.Name = "lblFeedbackPeriod";
            this.lblFeedbackPeriod.Size = new System.Drawing.Size(48, 13);
            this.lblFeedbackPeriod.TabIndex = 7;
            this.lblFeedbackPeriod.Text = "Период:";
            // 
            // lblFeedbackCapacity
            // 
            this.lblFeedbackCapacity.AutoSize = true;
            this.lblFeedbackCapacity.Location = new System.Drawing.Point(9, 22);
            this.lblFeedbackCapacity.Name = "lblFeedbackCapacity";
            this.lblFeedbackCapacity.Size = new System.Drawing.Size(76, 13);
            this.lblFeedbackCapacity.TabIndex = 6;
            this.lblFeedbackCapacity.Text = "Разрядность:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(862, 482);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(44, 13);
            this.lblTime.TabIndex = 18;
            this.lblTime.Text = "t = 0 ms";
            // 
            // timChangeText
            // 
            this.timChangeText.Interval = 400;
            this.timChangeText.Tick += new System.EventHandler(this.timChangeText_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 512);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.grbInfo);
            this.Controls.Add(this.grbCorrelation);
            this.Controls.Add(this.grbSingleFeedback);
            this.Controls.Add(this.grbMultipleFeedbacks);
            this.Controls.Add(this.grbSaveToFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1010, 545);
            this.Name = "MainForm";
            this.Text = "Генератор М-последовательности";
            ((System.ComponentModel.ISupportInitialize)(this.numDiscreteInMinPulse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaveRepeat)).EndInit();
            this.grbSaveToFile.ResumeLayout(false);
            this.grbSaveToFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSaveLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaveStart)).EndInit();
            this.grbMultipleFeedbacks.ResumeLayout(false);
            this.grbMultipleFeedbacks.PerformLayout();
            this.grbSingleFeedback.ResumeLayout(false);
            this.grbSingleFeedback.PerformLayout();
            this.grbCorrelation.ResumeLayout(false);
            this.grbCorrelation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCorrelationPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCorEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCorStart)).EndInit();
            this.grbInfo.ResumeLayout(false);
            this.grbInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numDiscreteInMinPulse;
        private System.Windows.Forms.NumericUpDown numSaveRepeat;
        private System.Windows.Forms.Panel panelFeedbacks;
        private System.Windows.Forms.Label lblSingleFeedbackIsMls;
        private System.Windows.Forms.GroupBox grbSaveToFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAllFeedbackCount;
        private System.Windows.Forms.Button btnFindNextFeedback;
        private System.Windows.Forms.TextBox txtSingleFeedbackHex;
        private System.Windows.Forms.GroupBox grbMultipleFeedbacks;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnFindAllFeedback;
        private System.Windows.Forms.GroupBox grbSingleFeedback;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFormatView;
        private System.Windows.Forms.NumericUpDown numSaveLen;
        private System.Windows.Forms.NumericUpDown numSaveStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtAllFeedbacksList;
        private System.Windows.Forms.Button btnBuildGraphics;
        private System.Windows.Forms.Button btnFindAllCorPeak;
        private System.Windows.Forms.GroupBox grbCorrelation;
        private System.Windows.Forms.GroupBox grbInfo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbCorrelationMethod;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDnl;
        private System.Windows.Forms.TextBox txtTimeConstant;
        private System.Windows.Forms.ComboBox cmbPowNl;
        private System.Windows.Forms.NumericUpDown numCorEnd;
        private System.Windows.Forms.NumericUpDown numCorStart;
        private System.Windows.Forms.NumericUpDown numCorrelationPeriods;
        private System.Windows.Forms.TextBox txtSingleFeedbackDec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblFeedbackPeriod;
        private System.Windows.Forms.Label lblFeedbackCapacity;
        private System.Windows.Forms.TextBox txtMaxFeedbackCnt;
        private System.Windows.Forms.TextBox txtFeedbackPeriod;
        private System.Windows.Forms.TextBox txtFeedbackNbits;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtSingleFeedbackIsMls;
        private System.Windows.Forms.Timer timChangeText;
    }
}

