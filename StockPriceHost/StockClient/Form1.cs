using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using StockNewsService;
using StockPriceService;
using StockMarketService;
using ForecastService;

namespace StockClient
{
    public partial class Form1 : Form, IForecastServiceCallback
    {
        IStockPrice stockPriceProxy;
        IStockNews stockNewsProxy;
        IFinancialIndicatorService stockFinanceProxy;
        IForecastService stockForecastProxy;
        List<Control> newsControl;
        List<Control> analysisControl;

        public Form1()
        {
            InitializeComponent();

            try
            {
                newsControl = new List<Control>();
                analysisControl = new List<Control>();

                EndpointAddress stockPriceAddress = new EndpointAddress("http://localhost:90/StockPrice");
                EndpointAddress stockNewsAddress = new EndpointAddress("http://localhost:90/StockNews");
                EndpointAddress stockFinanceAddress = new EndpointAddress("http://localhost:90/StockFinance");
                EndpointAddress stockForecastAddress = new EndpointAddress("http://localhost:90/StockForecast");

                BasicHttpBinding stockPriceBinding = new BasicHttpBinding();
                BasicHttpBinding stockNewsBinding = new BasicHttpBinding();
                WSDualHttpBinding stockForecastBinding = new WSDualHttpBinding();
                stockForecastBinding.ClientBaseAddress = new Uri("http://localhost:90/");

                stockPriceProxy = ChannelFactory<IStockPrice>.CreateChannel(stockPriceBinding, stockPriceAddress);
                stockNewsProxy = ChannelFactory<IStockNews>.CreateChannel(stockNewsBinding, stockNewsAddress);
                stockFinanceProxy = ChannelFactory<IFinancialIndicatorService>.CreateChannel(new BasicHttpBinding(), stockFinanceAddress);
                
                InstanceContext insContext = new InstanceContext(this);
                stockForecastProxy = new ForecastServiceClient(insContext, stockForecastBinding, stockForecastAddress);

                List<string[]> mostIncrease = stockPriceProxy.GetMostIncrease();
                List<string[]> mostDecrease = stockPriceProxy.GetMostDecrease();
                List<string[]> mostTraded = stockPriceProxy.GetMostTraded();

                DataTable mostIncreaseSource = ToDataTable(mostIncrease, new string[] { "Stock", "Open", "High", "Low", "Close", "Volume", "Change(%)" }, new int[] { 1, 3, 4, 5, 6, 7, 8 });
                DataTable mostDecreaseSource = ToDataTable(mostDecrease, new string[] { "Stock", "Open", "High", "Low", "Close", "Volume", "Change(%)" }, new int[] { 1, 3, 4, 5, 6, 7, 8 });
                DataTable mostTradedSource = ToDataTable(mostTraded, new string[] { "Stock", "Open", "High", "Low", "Close", "Volume" }, 5);

                dgvMostIncrease.DataSource = mostIncreaseSource;
                dgvMostDecrease.DataSource = mostDecreaseSource;
                dgvMostTraded.DataSource = mostTradedSource;

                int colCount = dgvMostIncrease.Columns.Count;
                int colWidth = (dgvMostIncrease.Width - 41) / 7;

                AutoSizeColumns(dgvMostIncrease, new int[] { 69, 69, 69, 69, 69, 69, 68 });
                AutoSizeColumns(dgvMostDecrease, new int[] { 69, 69, 69, 69, 69, 69, 68 });
                AutoSizeColumns(dgvMostTraded, new int[] { 80, 80, 80, 80, 81, 81 });

                AddNews(stockNewsProxy.GetNews("", Convert.ToInt32(txtViewCount.Value)));
                AddAnalysis(stockNewsProxy.GetExpertAnalysis("", Convert.ToInt32(txtAnalysisCount.Value)));

                List<string[]> periodsList = stockFinanceProxy.GetPeriods("HNM");
                foreach (string[] period in periodsList)
                {
                    string result = "Q" + period[0] + "/" + period[1];
                    cbbQuarter.Items.Add(result);
                }
                cbbQuarter.SelectedIndex = cbbQuarter.Items.Count - 1;

                cbbForecastsNum.SelectedIndex = cbbForecastsNum.Items.Count - 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error connecting to service. Press OK to quit");
                Environment.Exit(-1);
            }
        }

        private DataTable ToDataTable(List<string[]> input, string[] columnNames, int[] indexes)
        {
            DataTable result = new DataTable();

            foreach (string i in columnNames)
            {
                result.Columns.Add(i);
            }

            foreach (string[] i in input)
            {
                DataRow row = result.NewRow();

                for (int j = 0; j < indexes.Length; j++)
                {
                    row[j] = i[indexes[j]];
                }

                result.Rows.Add(row);
            }

            return result;
        }

        private DataTable ToDataTable(List<string[]> input, string[] columnNames, int rowLimit)
        {
            DataTable result = new DataTable();

            foreach (string i in columnNames)
            {
                result.Columns.Add(i);
            }

            for (int i = 0; i < rowLimit; i++)
            {
                string[] record = input[i];
                DataRow row = result.NewRow();

                for (int j = 0; j < record.Length; j++)
                {
                    row[j] = record[j];
                }

                result.Rows.Add(row);
            }

            return result;
        }

        private void AutoSizeColumns(DataGridView dgv)
        {
            int colCount = dgv.Columns.Count;
            int colWidth = (dgv.Width - 41) / colCount;

            for (int i = 0; i < colCount; i++)
            {
                DataGridViewColumn column = dgv.Columns[i]; 

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgv.Columns[i].Width = colWidth;
            }
        }

        private void AutoSizeColumns(DataGridView dgv, int[] colWidths)
        {
            int colCount = dgv.Columns.Count;

            for (int i = 0; i < colCount; i++)
            {
                DataGridViewColumn column = dgv.Columns[i];

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgv.Columns[i].Width = colWidths[i];
            }
        }

        private void AddNews(List<string[]> input)
        {
            int y = 46;

            foreach (Control i in newsControl)
            {
                tabNews.Controls.Remove(i);
            }

            newsControl.Clear();

            txtTickerNews.Text = "";

            foreach (string[] row in input)
            {
                //Panel container = new Panel();

                LinkLabel title = new LinkLabel();
                title.MaximumSize = new Size(tabControl1.TabPages["tabNews"].Width - 25, 0);
                title.AutoSize = true;
                title.Text = row[1];
                title.Links.Add(0, 500, row[4]);
                title.LinkClicked += LinkClicked;
                title.Font = new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold);
                title.LinkColor = Color.Gray;

                Label date = new Label();
                date.MaximumSize = new Size(tabControl1.TabPages["tabNews"].Width - 25, 0);
                date.AutoSize = true;
                date.Text = row[2];
                date.Font = new System.Drawing.Font(new FontFamily("Arial"), 9, FontStyle.Italic);
                date.ForeColor = Color.Silver;
                
                Label desc = new Label();
                desc.MaximumSize = new Size(tabControl1.TabPages["tabNews"].Width - 25, 0);
                desc.AutoSize = true;
                desc.Text = row[3];
                desc.Font = new System.Drawing.Font(new FontFamily("Arial"), 9, FontStyle.Regular);
                desc.ForeColor = Color.Gray;

                LineSeparator separator = new LineSeparator(1, tabControl1.TabPages["tabNews"].Width - 25);

                newsControl.Add(title);
                newsControl.Add(date);
                newsControl.Add(desc);
                newsControl.Add(separator);

                this.tabControl1.TabPages["tabNews"].Controls.Add(title);
                this.tabControl1.TabPages["tabNews"].Controls.Add(date);
                this.tabControl1.TabPages["tabNews"].Controls.Add(desc);
                this.tabControl1.TabPages["tabNews"].Controls.Add(separator);

                title.Location = new Point(5, y);
                date.Location = new Point(5, y + title.Height);
                desc.Location = new Point(5, y + title.Height + date.Height + 3);
                separator.Location = new Point(5, y + title.Height + date.Height + desc.Height + 15);

                y += title.Height + desc.Height + date.Height + 25;
            }
        }

        private void AddAnalysis(List<string[]> input)
        {
            int y = 46;

            foreach (Control i in analysisControl)
            {
                tabAnalysis.Controls.Remove(i);
            }

            analysisControl.Clear();

            foreach (string[] row in input)
            {
                //Panel container = new Panel();

                LinkLabel title = new LinkLabel();
                title.MaximumSize = new Size(tabControl1.TabPages["tabAnalysis"].Width - 25, 0);
                title.AutoSize = true;
                title.Text = row[1];
                title.Links.Add(0, 500, row[4]);
                title.LinkClicked += LinkClicked;
                title.Font = new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold);
                title.LinkColor = Color.Gray;

                Label date = new Label();
                date.MaximumSize = new Size(tabControl1.TabPages["tabAnalysis"].Width - 25, 0);
                date.AutoSize = true;
                date.Text = row[2];
                date.Font = new System.Drawing.Font(new FontFamily("Arial"), 9, FontStyle.Italic);
                date.ForeColor = Color.Silver;

                Label desc = new Label();
                desc.MaximumSize = new Size(tabControl1.TabPages["tabAnalysis"].Width - 25, 0);
                desc.AutoSize = true;
                desc.Text = row[3];
                desc.Font = new System.Drawing.Font(new FontFamily("Arial"), 9, FontStyle.Regular);
                desc.ForeColor = Color.Gray;

                LineSeparator separator = new LineSeparator(1, tabControl1.TabPages["tabAnalysis"].Width - 25);

                analysisControl.Add(title);
                analysisControl.Add(date);
                analysisControl.Add(desc);
                analysisControl.Add(separator);

                this.tabControl1.TabPages["tabAnalysis"].Controls.Add(title);
                this.tabControl1.TabPages["tabAnalysis"].Controls.Add(date);
                this.tabControl1.TabPages["tabAnalysis"].Controls.Add(desc);
                this.tabControl1.TabPages["tabAnalysis"].Controls.Add(separator);

                title.Location = new Point(5, y);
                date.Location = new Point(5, y + title.Height);
                desc.Location = new Point(5, y + title.Height + date.Height + 3);
                separator.Location = new Point(5, y + title.Height + date.Height + desc.Height + 15);

                y += title.Height + desc.Height + date.Height + 25;
            }
        }

        private void btnGetPrice_Click(object sender, EventArgs e)
        {
            string ticker = txtTicker.Text.Trim();

            if (ticker != "")
            {
                try
                {
                    List<string[]> records = stockPriceProxy.GetPrice(ticker, 11);

                    if (records.Count > 0)
                    {
                        DataTable dataSource = ToDataTable(records, new string[] { "Date", "Open", "Hight", "Low", "Close", "Volume", "Change(%)" }, 10);

                        dgvStockPrice.DataSource = dataSource;

                        AutoSizeColumns(dgvStockPrice, new int[] { 72, 72, 72, 72, 72, 72, 70 });
                    }
                    else
                    {
                        MessageBox.Show("No data found for '" + ticker + "'");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to service");
                }
            }
            else
            {
                MessageBox.Show("Please enter a stock to get price");
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            try
            {
                AddNews(stockNewsProxy.GetNews("", Convert.ToInt32(txtViewCount.Value)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to service");
            }
        }

        private void btnGetNews_Click(object sender, EventArgs e)
        {
            string ticker = txtTickerNews.Text.Trim();

            if (ticker != "")
            {
                try
                {
                    List<string[]> records = stockNewsProxy.GetNews(ticker, Convert.ToInt32(txtViewCount.Value));

                    if (records.Count > 0)
                    {
                        AddNews(records);
                    }
                    else
                    {
                        MessageBox.Show("No data found for '" + ticker + "'");
                        txtTickerNews.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to service");
                }
            }
            else
            {
                MessageBox.Show("Please enter a stock to get news");
            }
        }

        private void btnGetAllAnalysis_Click(object sender, EventArgs e)
        {
            try
            {
                AddAnalysis(stockNewsProxy.GetExpertAnalysis("", Convert.ToInt32(txtAnalysisCount.Value)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to service");
            }
        }

        private void btnGetAnalysis_Click(object sender, EventArgs e)
        {
            string ticker = txtTickerAnalysis.Text.Trim();

            if (ticker != "")
            {
                try
                {
                    List<string[]> records = stockNewsProxy.GetExpertAnalysis(ticker, Convert.ToInt32(txtAnalysisCount.Value));

                    if (records.Count > 0)
                    {
                        AddAnalysis(records);
                    }
                    else
                    {
                        MessageBox.Show("No data found for '" + ticker + "'");
                        txtTickerAnalysis.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to service");
                }
            }
            else
            {
                MessageBox.Show("Please enter a stock to get news");
            }
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            e.Link.Visited = true;

            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void txtViewCount_ValueChanged(object sender, EventArgs e)
        {
            string ticker = txtTickerNews.Text;

            if (ticker != "")
            {
                try
                {
                    List<string[]> records = stockNewsProxy.GetNews(ticker, Convert.ToInt32(txtViewCount.Value));

                    if (records.Count > 0)
                    {
                        AddNews(records);
                    }
                    else
                    {
                        MessageBox.Show("No data found for '" + ticker + "'");

                        txtTickerNews.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to service");
                }
            }
            else
            {
                try
                {
                    txtTickerNews.Text = "";

                    AddNews(stockNewsProxy.GetNews("", Convert.ToInt32(txtViewCount.Value)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to service");
                }
            }
        }

        private void txtAnalysisCount_ValueChanged(object sender, EventArgs e)
        {
            string ticker = txtTickerAnalysis.Text;

            if (ticker != "")
            {
                try
                {
                    List<string[]> records = stockNewsProxy.GetExpertAnalysis(ticker, Convert.ToInt32(txtAnalysisCount.Value));

                    if (records.Count > 0)
                    {
                        AddAnalysis(records);
                    }
                    else
                    {
                        MessageBox.Show("No data found for '" + ticker + "'");

                        txtTickerAnalysis.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to service");
                }
            }
            else
            {
                try
                {
                    txtTickerAnalysis.Text = "";

                    AddAnalysis(stockNewsProxy.GetExpertAnalysis("", Convert.ToInt32(txtAnalysisCount.Value)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to service");
                }
            }
        }

        public void SendResult(List<Forecast> result)
        {
            int round = 2;
            List<string[]> data = new List<string[]>();
            int length = result.Count;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    string[] newRow = new string[3];
                    newRow[0] = Math.Round(result[i].ForecastVal, round).ToString();
                    double belowConfi50, aboveConfi50, belowConfi95, aboveConfi95;
                    belowConfi50 = Math.Round(result[i].ForecastVal - result[i].Limit50, round);
                    aboveConfi50 = Math.Round(result[i].ForecastVal + result[i].Limit50, round);
                    newRow[1] = belowConfi50.ToString() + " - " + aboveConfi50.ToString();
                    belowConfi95 = Math.Round(result[i].ForecastVal - result[i].Limit95, round);
                    aboveConfi95 = Math.Round(result[i].ForecastVal + result[i].Limit95, round);
                    newRow[2] = belowConfi95.ToString() + " - " + aboveConfi95.ToString();

                    data.Add(newRow);
                }

                DataTable forecasts = ToDataTable(data, new string[] { "Forecast", "50% Confidence", "95% Confidence" }, new int[] { 0, 1, 2 });
                dgvForecast.DataSource = forecasts;
                dgvForecastGeneral.DataSource = forecasts;
                AutoSizeColumns(dgvForecast);
                AutoSizeColumns(dgvForecastGeneral);
            }
            else
            {
                MessageBox.Show("No data found for '" + txtTickerForecast.Text + "'");
            }
        }

        private void btnGetFinancialReport_Click(object sender, EventArgs e)
        {
            if (txtTickerFinance.Text != "")
            {
                string ticker = txtTickerFinance.Text;
                ticker = ticker.ToUpper();
                List<string[]> periodsList = stockFinanceProxy.GetPeriods(ticker);
                if (periodsList.Count > 0)
                {
                    List<FinancialRecord> financialReport = stockFinanceProxy.GetFinancialReport(ticker);

                    // Tạo cột Title
                    dgvFinancialReport.Columns.Add("Title", "Title");

                    // Tạo các cột quý chứa giá trị
                    int noOfValueColumns = periodsList.Count;
                    string columnNameHeader;
                    for (int i = 0; i < noOfValueColumns; i++)
                    {
                        columnNameHeader = periodsList[i][0] + "/" + periodsList[i][1];
                        dgvFinancialReport.Columns.Add(columnNameHeader, columnNameHeader);
                    }

                    string[] record;
                    int noOfColumns = noOfValueColumns + 1;
                    foreach (FinancialRecord financialrecord in financialReport)
                    {
                        record = new string[noOfColumns];
                        record[0] = financialrecord.Title;

                        for (int i = 1; i < noOfColumns; i++)
                        {
                            record[i] = financialrecord.Value[i - 1].ToString();
                        }

                        // add the record to the gridview
                        dgvFinancialReport.Rows.Add(record);
                    }
                }
                else {
                    MessageBox.Show("No data found for '" + txtTickerFinance.Text + "'");
                }
            }
            else 
            {
                MessageBox.Show("Please enter ticker!");
            }
        }

        private void btnGetFinancialIndex_Click(object sender, EventArgs e)
        {
            if (txtTickerFinance.Text != "")
            {
                if (cbbQuarter.Items.Count > 0)
                {
                    string ticker = txtTickerFinance.Text;
                    ticker = ticker.ToUpper();
                    string quarter = cbbQuarter.Text;
                    quarter = quarter.Substring(1);
                    List<FIItem> fiBasicItemList = stockFinanceProxy.GetTheBasicIndicators(ticker, quarter, false);
                    dgvFinancialIndex.DataSource = fiBasicItemList;
                    dgvFinancialIndex.Columns.Remove("ID");
                    AutoSizeColumns(dgvFinancialIndex);
                }
                else
                {
                    MessageBox.Show("No data found for '" + txtTickerFinance.Text + "'");
                }
            }
            else
            {
                MessageBox.Show("Please enter ticker!");
            }
        }

        private void btnGetForecasts_Click(object sender, EventArgs e)
        {
            if (txtTickerForecast.Text != "")
            {
                string ticker = txtTickerForecast.Text;
                ticker = ticker.ToUpper();
                int forecastsNum = Convert.ToInt16(cbbForecastsNum.Text);
                stockForecastProxy.GetForecastData(ticker, forecastsNum);
            }
            else
            {
                MessageBox.Show("Please enter ticker!");
            }
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            if (txtTickerGeneral.Text != "")
            {
                string ticker = txtTickerGeneral.Text;
                ticker = ticker.ToUpper().Trim();
                try
                {
                    txtTicker.Text = ticker;
                    txtTickerAnalysis.Text = ticker;
                    txtTickerFinance.Text = ticker;
                    txtTickerForecast.Text = ticker;
                    txtTickerNews.Text = ticker;

                    List<string[]> records = stockPriceProxy.GetPrice(ticker, 11);

                    if (records.Count > 0)
                    {
                        DataTable dataSource = ToDataTable(records, new string[] { "Date", "Open", "Hight", "Low", "Close", "Volume", "Change(%)" }, 10);

                        dgvPriceGeneral.DataSource = dataSource;

                        AutoSizeColumns(dgvPriceGeneral, new int[] { 72, 72, 72, 72, 72, 72, 70 });
                    }
                    else
                    {
                        MessageBox.Show("No data found for '" + ticker + "'");
                    }
                    
                    int forecastsNum = Convert.ToInt16(cbbForecastsNum.Text);
                    stockForecastProxy.GetForecastData(ticker, forecastsNum);

                    string quarter = cbbQuarter.Items[(cbbQuarter.Items.Count - 1)].ToString();
                    quarter = quarter.Substring(1);
                    List<FIItem> fiBasicItemList = stockFinanceProxy.GetTheBasicIndicators(ticker, quarter, false);
                    dgvIndexGeneral.DataSource = fiBasicItemList;
                    dgvIndexGeneral.Columns.Remove("ID");
                    AutoSizeColumns(dgvIndexGeneral);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Error connecting to server!");
                }
            }
            else
            {
                MessageBox.Show("Please enter ticker!");
            }
        }
    }
}
