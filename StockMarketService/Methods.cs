using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarketService
{
    public class Methods
    {
        #region Variables Definition
        private string query;

        #endregion

        #region Public methods

        // Xác định giá đóng cửa ngày gần nhất
        public decimal GetTheNewestClosePrice(string stockCode)
        {
            query = "SELECT close FROM stock_price WHERE stock_code = '" + stockCode + "' ORDER BY date DESC LIMIT 1";
            var result = ExecuteQuery(query)[0];
            return Convert.ToDecimal(result[0]) * 1000;
        }

        // Xác định giá cao nhất trong 52 tuần
        public double GetTheHighestClosePrice_52W(string stockCode)
        {
            query = "SELECT MAX(close) FROM week_price WHERE stock_code = '" + stockCode + "' LIMIT 52";
            //return ConvertListStringToInt(ExecuteQuery(query));
            return Convert.ToDouble((ExecuteQuery(query)[0])[0]);
        }

        // Xác định giá thấp nhất trong 52 tuần
        public double GetTheLowestClosePrice_52W(string stockCode)
        {
            query = "SELECT MIN(close) FROM week_price WHERE stock_code = '" + stockCode + "' LIMIT 52";
            return Convert.ToDouble((ExecuteQuery(query)[0])[0]);
        }

        // Lợi nhuận sau thuế
        public double GetSumProfitAfterTax(string stockCode, string currentPeriod)
        {
            double sum = 0;
            string[] period = GetAPeriod(currentPeriod);
            query = "SELECT value FROM finance_info WHERE ref_id = 60 AND stock_code = '" + stockCode + "' ORDER BY year DESC LIMIT 4";
            List<string[]> result = ExecuteQuery(query);
            foreach (var item in result)
            {
                sum += Convert.ToDouble(item[0]);
            }
            return sum;
        }

        // Tính giá trị beta
        public double CalculateBetaValue(string stockCode)
        {
            string getVnindexDataQuery = "SELECT close FROM stock_price WHERE stock_code = '^VNINDEX' ORDER BY date DESC LIMIT 100";
            string getStockDataQuery = "SELECT close FROM stock_price WHERE stock_code = '" + stockCode + "' ORDER BY date DESC LIMIT 100";
            List<double> listRm = CalculateRValue(getVnindexDataQuery);     // Tỷ suất sinh lời của thị trường VN-Index
            List<double> listRi = CalculateRValue(getStockDataQuery);       // Tỷ suất sinh lời của chứng khoán

            double varRm = CalculateVariance(listRm);
            double covRiRm = CalculateCovariance(listRi, listRm);
            return covRiRm / varRm;
        }

        /* Khi chưa đăng nhập, sẽ chỉ hiện thị những số liệu cơ bản như:
         * Giá hiện tại
         * EPS, P/E, ROA, ROE, P/B
         * Khối lượng giao dịch
         * Beta
         */
        public List<string[]> GetBasicIndicator(string stockCode, string currentPeriod)
        {
            string[] period = GetAPeriod(currentPeriod);
            query = SetGetDataQuery(stockCode, period[0], period[1], false);
            return ExecuteQuery(query);
        }

        public List<IndicatorItem> GetFinancialReport(string stockCode, string quarter, string year)
        {
            query = SetGetDataQuery(stockCode, quarter, year, true);
            List<IndicatorItem> indicatorItemList = new List<IndicatorItem> { };
            List<string[]> items = ExecuteQuery(query);
            foreach (var item in items)
            {
                IndicatorItem indicatorItem = new IndicatorItem();
                indicatorItem.Value = Convert.ToDouble(item[2]);
                indicatorItem.Title = item[1];
                indicatorItemList.Add(indicatorItem);
            }
            return indicatorItemList;
        }

        /* Xác định giá trị của 1 chỉ số tài chính
         * result[0] --> ID
         * result[1] --> Title
         * result[2] --> Value
         * result[3] --> Display or not
         */
        //public long FindTheValueOfIndicator(List<string[]> indicatorList, string indicatorID)
        //{
        //    string[] result = indicatorList.Find(
        //        delegate(string[] item)
        //        {
        //            return item[0] == indicatorID;
        //        });
        //    if (result != null)
        //    {
        //        return Convert.ToInt64(result[2]);
        //    }
        //    return 0;
        //}

        public IndicatorItem FindIndicatorItem(List<string[]> indicatorList, string indicatorID)
        {
            IndicatorItem indicatorItem = new IndicatorItem();
            string[] result = indicatorList.Find(
                delegate(string[] item)
                {
                    return item[0] == indicatorID;
                });
            if (result != null)
            {
                indicatorItem.Title = result[1];
                indicatorItem.Value = Convert.ToDouble(result[2]);
                return indicatorItem;
            }
            return null;
        }

        public void InsertIntoFiBasicItemList(ref List<FIItem> fiBasicItemList, string name, double value)
        {
            FIItem fiBasicItem = new FIItem();
            fiBasicItem.Name = name;
            fiBasicItem.Value = value;
            fiBasicItemList.Add(fiBasicItem);
        }

        public void InsertIntoFilterDataList(ref List<FIItem> filterDataList, string id, string name, double value)
        {
            FIItem filterDataItem = new FIItem();
            filterDataItem.ID = id;
            filterDataItem.Name = name;
            filterDataItem.Value = value;
            filterDataList.Add(filterDataItem);
        }

        public void InsertToFilterTable(List<FIItem> filterDataList)
        {
            OLEDB.Database.InsertToFilterTable(filterDataList);
        }

        #endregion


        # region Private methods
        // Thực thi các câu query
        private List<string[]> ExecuteQuery(string query)
        {
            return OLEDB.Database.Query(query);
        }

        // Trả về duy nhất 1 giá trị trong kết quả trả về
        private int ConvertListStringToInt(List<string[]> input)
        {
            var output = input[0];
            return Convert.ToInt16(output[0]);
        }

        /*  Phân tách ra thành quý mấy, năm mấy
         *  arrTime[0] --> quý
         *  arrTime[1] --> năm
         */
        private string[] GetAPeriod(string currentPeriod)
        {
            return currentPeriod.Split('/');
        }

        // Tập hợp các quý có trong DB
        //public List<string> GetPeriodsFromDB()
        //{
        //    query = "SELECT quarter, year FROM finance_info GROUP BY year, quarter";
        //    List<string> result = new List<string> { };
        //    List<string[]> periods = ExecuteQuery(query);
        //    foreach (var period in periods)
        //        result.Add(period[0] + "/" + period[1]);
        //    return result;
        //}
        public List<Period> GetPeriodsFromDB(string stockCode)
        {
            query = "SELECT quarter, year FROM finance_info WHERE stock_code = '" + stockCode + "' GROUP BY year, quarter";
            List<Period> periodsList = new List<Period> { };
            List<string[]> periods = ExecuteQuery(query);
            foreach (var item in periods)
            {
                Period period = new Period();
                period.Quarter = item[0];
                period.Year = item[1];
                periodsList.Add(period);
            }
            return periodsList;
        }

        // Tạo câu query truy xuất dữ liệu
        public string SetGetDataQuery(string stockCode, string quarter, string year, bool isDisplay)
        {
            string result = "SELECT info.ref_id, ref.reference, value " +
                            "FROM finance_info AS info " +
                            "INNER JOIN finance_reference AS ref " +
                            "ON info.ref_id = ref.ref_id " +
                            "WHERE stock_code = '" + stockCode + "' " +
                            "AND year = '" + year + "' " +
                            "AND quarter = '" + quarter + "' ";
            //if (isDisplay)
            //    result += "AND display = 1";
            return result;

        }

        // Tính giá trị R --> dùng trong tính toán beta
        private List<double> CalculateRValue(string getDataQuery)
        {
            //string query = "SELECT close FROM stock_price WHERE stock_code = '^VNINDEX' ORDER BY date DESC LIMIT 100";
            List<double> arrR = new List<double> { };
            List<string[]> reData = ExecuteQuery(getDataQuery);

            int noOfReData = reData.Count - 1;
            for (int i = 0; i < noOfReData; i++)
            {
                arrR.Add((Convert.ToDouble(reData[i + 1][0]) - Convert.ToDouble(reData[i][0])) / Convert.ToDouble(reData[i][0]));
            }
            return arrR;
        }

        // Tính phương sai
        private double CalculateVariance(List<double> data)
        {
            double sum = 0, sumSqr = 0, mean = 0, variance = 0;
            int n = 0;
            for (int i = 0; i < 99; i++)
            {
                n = n + 1;
                sum = data[i];
                sumSqr = sumSqr + data[i] * data[i];
            }
            mean = sum / n;
            variance = (sumSqr - sum * mean) / (n - 1);
            return variance;
        }

        // Tính hiệp phương sai
        private double CalculateCovariance(List<double> dataRi, List<double> dataRm)
        {
            int n = 99;     //dataRi.Count;
            double meanRi = dataRi.Sum() / n;
            double meanRm = dataRm.Sum() / n;
            double covariance = 0, a = 0, b = 0;
            for (int i = 0; i < n; i++)
            {
                a = dataRi[i] - meanRi;
                b = dataRm[i] - meanRm;
                covariance += a * b / n;
            }
            return covariance;
        }

        # endregion
    }

    public class Period
    {
        public string Quarter { get; set; }
        public string Year { get; set; }
    }

    // chỉ số tài chính từ BCTC
    public class IndicatorItem
    {        
        public string Title { get; set; }
        public double Value { get; set; }
    }

    // Các chỉ số tính toán cơ bản    
    public class BasicIndicators
    {
        public string StockCode { get; set; }
        public double Fi_1 { get; set; }
        public double Fi_60 { get; set; }
        public double Fi_100 { get; set; }
        public double Fi_140 { get; set; }
        public double Fi_200 { get; set; }
        public double Fi_227 { get; set; }
        public double Fi_300 { get; set; }
        public double Fi_310 { get; set; }
        public double Fi_400 { get; set; }
        public double Fi_TOS { get; set; }
        public double QuickRatio { get; set; }
        public double ROE { get; set; }
        public double ROA { get; set; }
        public double FinancialLeverage { get; set; }
        public double NetProfitMargin { get; set; }
        public double BookValue { get; set; }
        public double PB { get; set; }
        public double Max52w { get; set; }
        public double Min52w { get; set; }
        public double EPSBasic { get; set; }
        public double PE { get; set; }
        public double Beta { get; set; }
        public decimal ClosePrice { get; set; }
        public double MarketCap { get; set; }
    }
}
