namespace StockClient
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStockPrice = new System.Windows.Forms.TabPage();
            this.btnGetPrice = new System.Windows.Forms.Button();
            this.dgvStockPrice = new System.Windows.Forms.DataGridView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvMostIncrease = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvMostDecrease = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvMostTraded = new System.Windows.Forms.DataGridView();
            this.txtTicker = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabNews = new System.Windows.Forms.TabPage();
            this.lineSeparator1 = new StockClient.LineSeparator();
            this.label4 = new System.Windows.Forms.Label();
            this.txtViewCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.btnGetNews = new System.Windows.Forms.Button();
            this.txtTickerNews = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabAnalysis = new System.Windows.Forms.TabPage();
            this.btnGetAllAnalysis = new System.Windows.Forms.Button();
            this.btnGetAnalysis = new System.Windows.Forms.Button();
            this.txtTickerAnalysis = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAnalysisCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lineSeparator2 = new StockClient.LineSeparator();
            this.tbpFinance = new System.Windows.Forms.TabPage();
            this.btnGetFinancialIndex = new System.Windows.Forms.Button();
            this.dgvFinancialIndex = new System.Windows.Forms.DataGridView();
            this.dgvFinancialReport = new System.Windows.Forms.DataGridView();
            this.cbbQuarter = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGetFinancialReport = new System.Windows.Forms.Button();
            this.txtTickerFinance = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbpForecast = new System.Windows.Forms.TabPage();
            this.dgvForecast = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.cbbForecastsNum = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGetForecasts = new System.Windows.Forms.Button();
            this.txtTickerForecast = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.dgvForecastGeneral = new System.Windows.Forms.DataGridView();
            this.dgvIndexGeneral = new System.Windows.Forms.DataGridView();
            this.dgvPriceGeneral = new System.Windows.Forms.DataGridView();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.txtTickerGeneral = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabStockPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockPrice)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostIncrease)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostDecrease)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostTraded)).BeginInit();
            this.tabNews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtViewCount)).BeginInit();
            this.tabAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnalysisCount)).BeginInit();
            this.tbpFinance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinancialIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinancialReport)).BeginInit();
            this.tbpForecast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForecast)).BeginInit();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForecastGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndexGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabStockPrice);
            this.tabControl1.Controls.Add(this.tbpForecast);
            this.tabControl1.Controls.Add(this.tbpFinance);
            this.tabControl1.Controls.Add(this.tabNews);
            this.tabControl1.Controls.Add(this.tabAnalysis);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(569, 485);
            this.tabControl1.TabIndex = 0;
            // 
            // tabStockPrice
            // 
            this.tabStockPrice.Controls.Add(this.btnGetPrice);
            this.tabStockPrice.Controls.Add(this.dgvStockPrice);
            this.tabStockPrice.Controls.Add(this.tabControl2);
            this.tabStockPrice.Controls.Add(this.txtTicker);
            this.tabStockPrice.Controls.Add(this.label1);
            this.tabStockPrice.Location = new System.Drawing.Point(4, 22);
            this.tabStockPrice.Name = "tabStockPrice";
            this.tabStockPrice.Padding = new System.Windows.Forms.Padding(3);
            this.tabStockPrice.Size = new System.Drawing.Size(561, 459);
            this.tabStockPrice.TabIndex = 0;
            this.tabStockPrice.Text = "Stock price";
            this.tabStockPrice.UseVisualStyleBackColor = true;
            // 
            // btnGetPrice
            // 
            this.btnGetPrice.Location = new System.Drawing.Point(154, 4);
            this.btnGetPrice.Name = "btnGetPrice";
            this.btnGetPrice.Size = new System.Drawing.Size(75, 23);
            this.btnGetPrice.TabIndex = 4;
            this.btnGetPrice.Text = "Get price";
            this.btnGetPrice.UseVisualStyleBackColor = true;
            this.btnGetPrice.Click += new System.EventHandler(this.btnGetPrice_Click);
            // 
            // dgvStockPrice
            // 
            this.dgvStockPrice.AllowUserToAddRows = false;
            this.dgvStockPrice.AllowUserToDeleteRows = false;
            this.dgvStockPrice.AllowUserToOrderColumns = true;
            this.dgvStockPrice.AllowUserToResizeColumns = false;
            this.dgvStockPrice.AllowUserToResizeRows = false;
            this.dgvStockPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockPrice.Location = new System.Drawing.Point(8, 32);
            this.dgvStockPrice.Name = "dgvStockPrice";
            this.dgvStockPrice.ReadOnly = true;
            this.dgvStockPrice.Size = new System.Drawing.Size(545, 243);
            this.dgvStockPrice.TabIndex = 3;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(8, 281);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(545, 171);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvMostIncrease);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(537, 145);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Most increase";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvMostIncrease
            // 
            this.dgvMostIncrease.AllowUserToAddRows = false;
            this.dgvMostIncrease.AllowUserToDeleteRows = false;
            this.dgvMostIncrease.AllowUserToResizeColumns = false;
            this.dgvMostIncrease.AllowUserToResizeRows = false;
            this.dgvMostIncrease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostIncrease.Location = new System.Drawing.Point(6, 6);
            this.dgvMostIncrease.Name = "dgvMostIncrease";
            this.dgvMostIncrease.ReadOnly = true;
            this.dgvMostIncrease.Size = new System.Drawing.Size(525, 133);
            this.dgvMostIncrease.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvMostDecrease);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(537, 145);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Most decrease";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvMostDecrease
            // 
            this.dgvMostDecrease.AllowUserToAddRows = false;
            this.dgvMostDecrease.AllowUserToDeleteRows = false;
            this.dgvMostDecrease.AllowUserToResizeColumns = false;
            this.dgvMostDecrease.AllowUserToResizeRows = false;
            this.dgvMostDecrease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostDecrease.Location = new System.Drawing.Point(6, 6);
            this.dgvMostDecrease.Name = "dgvMostDecrease";
            this.dgvMostDecrease.ReadOnly = true;
            this.dgvMostDecrease.Size = new System.Drawing.Size(525, 133);
            this.dgvMostDecrease.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvMostTraded);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(537, 145);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Most traded";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvMostTraded
            // 
            this.dgvMostTraded.AllowUserToAddRows = false;
            this.dgvMostTraded.AllowUserToDeleteRows = false;
            this.dgvMostTraded.AllowUserToResizeColumns = false;
            this.dgvMostTraded.AllowUserToResizeRows = false;
            this.dgvMostTraded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostTraded.Location = new System.Drawing.Point(6, 6);
            this.dgvMostTraded.Name = "dgvMostTraded";
            this.dgvMostTraded.ReadOnly = true;
            this.dgvMostTraded.Size = new System.Drawing.Size(525, 133);
            this.dgvMostTraded.TabIndex = 0;
            // 
            // txtTicker
            // 
            this.txtTicker.Location = new System.Drawing.Point(48, 6);
            this.txtTicker.Name = "txtTicker";
            this.txtTicker.Size = new System.Drawing.Size(100, 20);
            this.txtTicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticker";
            // 
            // tabNews
            // 
            this.tabNews.AutoScroll = true;
            this.tabNews.Controls.Add(this.lineSeparator1);
            this.tabNews.Controls.Add(this.label4);
            this.tabNews.Controls.Add(this.txtViewCount);
            this.tabNews.Controls.Add(this.label3);
            this.tabNews.Controls.Add(this.btnGetAll);
            this.tabNews.Controls.Add(this.btnGetNews);
            this.tabNews.Controls.Add(this.txtTickerNews);
            this.tabNews.Controls.Add(this.label2);
            this.tabNews.Location = new System.Drawing.Point(4, 22);
            this.tabNews.Name = "tabNews";
            this.tabNews.Padding = new System.Windows.Forms.Padding(3);
            this.tabNews.Size = new System.Drawing.Size(561, 459);
            this.tabNews.TabIndex = 1;
            this.tabNews.Text = "News";
            this.tabNews.UseVisualStyleBackColor = true;
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(8, 35);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(532, 2);
            this.lineSeparator1.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "news";
            // 
            // txtViewCount
            // 
            this.txtViewCount.Location = new System.Drawing.Point(459, 8);
            this.txtViewCount.Name = "txtViewCount";
            this.txtViewCount.Size = new System.Drawing.Size(45, 20);
            this.txtViewCount.TabIndex = 10;
            this.txtViewCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtViewCount.ValueChanged += new System.EventHandler(this.txtViewCount_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "View";
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(8, 6);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(75, 23);
            this.btnGetAll.TabIndex = 8;
            this.btnGetAll.Text = "Get all";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // btnGetNews
            // 
            this.btnGetNews.Location = new System.Drawing.Point(319, 6);
            this.btnGetNews.Name = "btnGetNews";
            this.btnGetNews.Size = new System.Drawing.Size(75, 23);
            this.btnGetNews.TabIndex = 7;
            this.btnGetNews.Text = "Get";
            this.btnGetNews.UseVisualStyleBackColor = true;
            this.btnGetNews.Click += new System.EventHandler(this.btnGetNews_Click);
            // 
            // txtTickerNews
            // 
            this.txtTickerNews.Location = new System.Drawing.Point(213, 8);
            this.txtTickerNews.Name = "txtTickerNews";
            this.txtTickerNews.Size = new System.Drawing.Size(100, 20);
            this.txtTickerNews.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Get news for";
            // 
            // tabAnalysis
            // 
            this.tabAnalysis.AutoScroll = true;
            this.tabAnalysis.Controls.Add(this.btnGetAllAnalysis);
            this.tabAnalysis.Controls.Add(this.btnGetAnalysis);
            this.tabAnalysis.Controls.Add(this.txtTickerAnalysis);
            this.tabAnalysis.Controls.Add(this.label7);
            this.tabAnalysis.Controls.Add(this.label5);
            this.tabAnalysis.Controls.Add(this.txtAnalysisCount);
            this.tabAnalysis.Controls.Add(this.label6);
            this.tabAnalysis.Controls.Add(this.lineSeparator2);
            this.tabAnalysis.Location = new System.Drawing.Point(4, 22);
            this.tabAnalysis.Name = "tabAnalysis";
            this.tabAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnalysis.Size = new System.Drawing.Size(561, 459);
            this.tabAnalysis.TabIndex = 2;
            this.tabAnalysis.Text = "Expert analysis";
            this.tabAnalysis.UseVisualStyleBackColor = true;
            // 
            // btnGetAllAnalysis
            // 
            this.btnGetAllAnalysis.Location = new System.Drawing.Point(8, 6);
            this.btnGetAllAnalysis.Name = "btnGetAllAnalysis";
            this.btnGetAllAnalysis.Size = new System.Drawing.Size(75, 23);
            this.btnGetAllAnalysis.TabIndex = 24;
            this.btnGetAllAnalysis.Text = "Get all";
            this.btnGetAllAnalysis.UseVisualStyleBackColor = true;
            this.btnGetAllAnalysis.Click += new System.EventHandler(this.btnGetAllAnalysis_Click);
            // 
            // btnGetAnalysis
            // 
            this.btnGetAnalysis.Location = new System.Drawing.Point(313, 6);
            this.btnGetAnalysis.Name = "btnGetAnalysis";
            this.btnGetAnalysis.Size = new System.Drawing.Size(75, 23);
            this.btnGetAnalysis.TabIndex = 23;
            this.btnGetAnalysis.Text = "Get";
            this.btnGetAnalysis.UseVisualStyleBackColor = true;
            this.btnGetAnalysis.Click += new System.EventHandler(this.btnGetAnalysis_Click);
            // 
            // txtTickerAnalysis
            // 
            this.txtTickerAnalysis.Location = new System.Drawing.Point(207, 8);
            this.txtTickerAnalysis.Name = "txtTickerAnalysis";
            this.txtTickerAnalysis.Size = new System.Drawing.Size(100, 20);
            this.txtTickerAnalysis.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Get analysis for";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(496, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "analysis";
            // 
            // txtAnalysisCount
            // 
            this.txtAnalysisCount.Location = new System.Drawing.Point(447, 8);
            this.txtAnalysisCount.Name = "txtAnalysisCount";
            this.txtAnalysisCount.Size = new System.Drawing.Size(45, 20);
            this.txtAnalysisCount.TabIndex = 18;
            this.txtAnalysisCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtAnalysisCount.ValueChanged += new System.EventHandler(this.txtAnalysisCount_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "View";
            // 
            // lineSeparator2
            // 
            this.lineSeparator2.Location = new System.Drawing.Point(8, 35);
            this.lineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator2.Name = "lineSeparator2";
            this.lineSeparator2.Size = new System.Drawing.Size(532, 2);
            this.lineSeparator2.TabIndex = 20;
            // 
            // tbpFinance
            // 
            this.tbpFinance.Controls.Add(this.btnGetFinancialIndex);
            this.tbpFinance.Controls.Add(this.dgvFinancialIndex);
            this.tbpFinance.Controls.Add(this.dgvFinancialReport);
            this.tbpFinance.Controls.Add(this.cbbQuarter);
            this.tbpFinance.Controls.Add(this.label9);
            this.tbpFinance.Controls.Add(this.btnGetFinancialReport);
            this.tbpFinance.Controls.Add(this.txtTickerFinance);
            this.tbpFinance.Controls.Add(this.label8);
            this.tbpFinance.Location = new System.Drawing.Point(4, 22);
            this.tbpFinance.Name = "tbpFinance";
            this.tbpFinance.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFinance.Size = new System.Drawing.Size(561, 459);
            this.tbpFinance.TabIndex = 3;
            this.tbpFinance.Text = "Finance";
            this.tbpFinance.UseVisualStyleBackColor = true;
            // 
            // btnGetFinancialIndex
            // 
            this.btnGetFinancialIndex.Location = new System.Drawing.Point(444, 302);
            this.btnGetFinancialIndex.Name = "btnGetFinancialIndex";
            this.btnGetFinancialIndex.Size = new System.Drawing.Size(104, 22);
            this.btnGetFinancialIndex.TabIndex = 12;
            this.btnGetFinancialIndex.Text = "Get financial index";
            this.btnGetFinancialIndex.UseVisualStyleBackColor = true;
            this.btnGetFinancialIndex.Click += new System.EventHandler(this.btnGetFinancialIndex_Click);
            // 
            // dgvFinancialIndex
            // 
            this.dgvFinancialIndex.AllowUserToAddRows = false;
            this.dgvFinancialIndex.AllowUserToDeleteRows = false;
            this.dgvFinancialIndex.AllowUserToOrderColumns = true;
            this.dgvFinancialIndex.AllowUserToResizeColumns = false;
            this.dgvFinancialIndex.AllowUserToResizeRows = false;
            this.dgvFinancialIndex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinancialIndex.Location = new System.Drawing.Point(3, 239);
            this.dgvFinancialIndex.Name = "dgvFinancialIndex";
            this.dgvFinancialIndex.ReadOnly = true;
            this.dgvFinancialIndex.Size = new System.Drawing.Size(418, 186);
            this.dgvFinancialIndex.TabIndex = 11;
            // 
            // dgvFinancialReport
            // 
            this.dgvFinancialReport.AllowUserToAddRows = false;
            this.dgvFinancialReport.AllowUserToDeleteRows = false;
            this.dgvFinancialReport.AllowUserToOrderColumns = true;
            this.dgvFinancialReport.AllowUserToResizeColumns = false;
            this.dgvFinancialReport.AllowUserToResizeRows = false;
            this.dgvFinancialReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinancialReport.Location = new System.Drawing.Point(3, 33);
            this.dgvFinancialReport.Name = "dgvFinancialReport";
            this.dgvFinancialReport.ReadOnly = true;
            this.dgvFinancialReport.Size = new System.Drawing.Size(545, 186);
            this.dgvFinancialReport.TabIndex = 10;
            // 
            // cbbQuarter
            // 
            this.cbbQuarter.FormattingEnabled = true;
            this.cbbQuarter.Location = new System.Drawing.Point(427, 263);
            this.cbbQuarter.Name = "cbbQuarter";
            this.cbbQuarter.Size = new System.Drawing.Size(121, 21);
            this.cbbQuarter.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(424, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Quarter";
            // 
            // btnGetFinancialReport
            // 
            this.btnGetFinancialReport.Location = new System.Drawing.Point(444, 4);
            this.btnGetFinancialReport.Name = "btnGetFinancialReport";
            this.btnGetFinancialReport.Size = new System.Drawing.Size(104, 23);
            this.btnGetFinancialReport.TabIndex = 7;
            this.btnGetFinancialReport.Text = "Get financial report";
            this.btnGetFinancialReport.UseVisualStyleBackColor = true;
            this.btnGetFinancialReport.Click += new System.EventHandler(this.btnGetFinancialReport_Click);
            // 
            // txtTickerFinance
            // 
            this.txtTickerFinance.Location = new System.Drawing.Point(48, 6);
            this.txtTickerFinance.Name = "txtTickerFinance";
            this.txtTickerFinance.Size = new System.Drawing.Size(100, 20);
            this.txtTickerFinance.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ticker";
            // 
            // tbpForecast
            // 
            this.tbpForecast.Controls.Add(this.dgvForecast);
            this.tbpForecast.Controls.Add(this.label12);
            this.tbpForecast.Controls.Add(this.cbbForecastsNum);
            this.tbpForecast.Controls.Add(this.label10);
            this.tbpForecast.Controls.Add(this.btnGetForecasts);
            this.tbpForecast.Controls.Add(this.txtTickerForecast);
            this.tbpForecast.Controls.Add(this.label11);
            this.tbpForecast.Location = new System.Drawing.Point(4, 22);
            this.tbpForecast.Name = "tbpForecast";
            this.tbpForecast.Padding = new System.Windows.Forms.Padding(3);
            this.tbpForecast.Size = new System.Drawing.Size(561, 459);
            this.tbpForecast.TabIndex = 4;
            this.tbpForecast.Text = "Forecast";
            this.tbpForecast.UseVisualStyleBackColor = true;
            // 
            // dgvForecast
            // 
            this.dgvForecast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForecast.Location = new System.Drawing.Point(8, 52);
            this.dgvForecast.Name = "dgvForecast";
            this.dgvForecast.Size = new System.Drawing.Size(545, 234);
            this.dgvForecast.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(370, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Forecasts";
            // 
            // cbbForecastsNum
            // 
            this.cbbForecastsNum.FormattingEnabled = true;
            this.cbbForecastsNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbbForecastsNum.Location = new System.Drawing.Point(313, 6);
            this.cbbForecastsNum.Name = "cbbForecastsNum";
            this.cbbForecastsNum.Size = new System.Drawing.Size(51, 21);
            this.cbbForecastsNum.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(277, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "View";
            // 
            // btnGetForecasts
            // 
            this.btnGetForecasts.Location = new System.Drawing.Point(154, 4);
            this.btnGetForecasts.Name = "btnGetForecasts";
            this.btnGetForecasts.Size = new System.Drawing.Size(90, 23);
            this.btnGetForecasts.TabIndex = 7;
            this.btnGetForecasts.Text = "Get forecasts";
            this.btnGetForecasts.UseVisualStyleBackColor = true;
            this.btnGetForecasts.Click += new System.EventHandler(this.btnGetForecasts_Click);
            // 
            // txtTickerForecast
            // 
            this.txtTickerForecast.Location = new System.Drawing.Point(48, 6);
            this.txtTickerForecast.Name = "txtTickerForecast";
            this.txtTickerForecast.Size = new System.Drawing.Size(100, 20);
            this.txtTickerForecast.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Ticker";
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.dgvForecastGeneral);
            this.tabGeneral.Controls.Add(this.dgvIndexGeneral);
            this.tabGeneral.Controls.Add(this.dgvPriceGeneral);
            this.tabGeneral.Controls.Add(this.btnGetInfo);
            this.tabGeneral.Controls.Add(this.txtTickerGeneral);
            this.tabGeneral.Controls.Add(this.label13);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(561, 459);
            this.tabGeneral.TabIndex = 5;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // dgvForecastGeneral
            // 
            this.dgvForecastGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForecastGeneral.Location = new System.Drawing.Point(251, 270);
            this.dgvForecastGeneral.Name = "dgvForecastGeneral";
            this.dgvForecastGeneral.Size = new System.Drawing.Size(302, 181);
            this.dgvForecastGeneral.TabIndex = 14;
            // 
            // dgvIndexGeneral
            // 
            this.dgvIndexGeneral.AllowUserToAddRows = false;
            this.dgvIndexGeneral.AllowUserToDeleteRows = false;
            this.dgvIndexGeneral.AllowUserToOrderColumns = true;
            this.dgvIndexGeneral.AllowUserToResizeColumns = false;
            this.dgvIndexGeneral.AllowUserToResizeRows = false;
            this.dgvIndexGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIndexGeneral.Location = new System.Drawing.Point(9, 270);
            this.dgvIndexGeneral.Name = "dgvIndexGeneral";
            this.dgvIndexGeneral.ReadOnly = true;
            this.dgvIndexGeneral.Size = new System.Drawing.Size(236, 181);
            this.dgvIndexGeneral.TabIndex = 12;
            // 
            // dgvPriceGeneral
            // 
            this.dgvPriceGeneral.AllowUserToAddRows = false;
            this.dgvPriceGeneral.AllowUserToDeleteRows = false;
            this.dgvPriceGeneral.AllowUserToOrderColumns = true;
            this.dgvPriceGeneral.AllowUserToResizeColumns = false;
            this.dgvPriceGeneral.AllowUserToResizeRows = false;
            this.dgvPriceGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceGeneral.Location = new System.Drawing.Point(8, 33);
            this.dgvPriceGeneral.Name = "dgvPriceGeneral";
            this.dgvPriceGeneral.ReadOnly = true;
            this.dgvPriceGeneral.Size = new System.Drawing.Size(545, 231);
            this.dgvPriceGeneral.TabIndex = 8;
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.Location = new System.Drawing.Point(155, 4);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(90, 23);
            this.btnGetInfo.TabIndex = 7;
            this.btnGetInfo.Text = "Get information";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // txtTickerGeneral
            // 
            this.txtTickerGeneral.Location = new System.Drawing.Point(49, 6);
            this.txtTickerGeneral.Name = "txtTickerGeneral";
            this.txtTickerGeneral.Size = new System.Drawing.Size(100, 20);
            this.txtTickerGeneral.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Ticker";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 485);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabStockPrice.ResumeLayout(false);
            this.tabStockPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockPrice)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostIncrease)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostDecrease)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostTraded)).EndInit();
            this.tabNews.ResumeLayout(false);
            this.tabNews.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtViewCount)).EndInit();
            this.tabAnalysis.ResumeLayout(false);
            this.tabAnalysis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnalysisCount)).EndInit();
            this.tbpFinance.ResumeLayout(false);
            this.tbpFinance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinancialIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinancialReport)).EndInit();
            this.tbpForecast.ResumeLayout(false);
            this.tbpForecast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForecast)).EndInit();
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForecastGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndexGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceGeneral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStockPrice;
        private System.Windows.Forms.DataGridView dgvStockPrice;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvMostIncrease;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtTicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabNews;
        private System.Windows.Forms.Button btnGetPrice;
        private System.Windows.Forms.DataGridView dgvMostDecrease;
        private System.Windows.Forms.DataGridView dgvMostTraded;
        private System.Windows.Forms.TabPage tabAnalysis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtViewCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Button btnGetNews;
        private System.Windows.Forms.TextBox txtTickerNews;
        private System.Windows.Forms.Label label2;
        private LineSeparator lineSeparator1;
        private LineSeparator lineSeparator2;
        private System.Windows.Forms.Button btnGetAllAnalysis;
        private System.Windows.Forms.Button btnGetAnalysis;
        private System.Windows.Forms.TextBox txtTickerAnalysis;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tbpFinance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGetFinancialReport;
        private System.Windows.Forms.TextBox txtTickerFinance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbQuarter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtAnalysisCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGetFinancialIndex;
        private System.Windows.Forms.DataGridView dgvFinancialIndex;
        private System.Windows.Forms.DataGridView dgvFinancialReport;
        private System.Windows.Forms.TabPage tbpForecast;
        private System.Windows.Forms.DataGridView dgvForecast;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbbForecastsNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGetForecasts;
        private System.Windows.Forms.TextBox txtTickerForecast;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.DataGridView dgvForecastGeneral;
        private System.Windows.Forms.DataGridView dgvIndexGeneral;
        private System.Windows.Forms.DataGridView dgvPriceGeneral;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.TextBox txtTickerGeneral;
        private System.Windows.Forms.Label label13;
    }
}

