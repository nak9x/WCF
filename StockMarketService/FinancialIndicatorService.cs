using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using OLEDB;

namespace StockMarketService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class FinancialIndicatorService : IFinancialIndicatorService
    {
        Methods myMethods = new Methods();
        string[] basicFis = { "1", "60", "100", "140", "200", "227", "300", "310", "400", "TOS", "closePrice" };
        BasicIndicators basicIndicator = new BasicIndicators();
        IndicatorItem indicatorItem = new IndicatorItem();
        
        public List<FIItem> GetTheBasicIndicators(string stockCode, string currentPeriod, bool isGetFilterData)
        {
            // indicatorList --> chứa các chỉ số dẫn xuất từ BCTC
            List<string[]> indicatorList = myMethods.GetBasicIndicator(stockCode, currentPeriod);

            // indicatorItemList
            List<IndicatorItem> indicatorItemList = new List<IndicatorItem>();
                        
            // fiBasicItemList --> chứa các chỉ số cơ bản được tính toán
            // chứa những chỉ số dùng cho Filter
            // dùng để binding datagrid --> hiển thị
            List<FIItem> resultList = new List<FIItem>();        


            /* Các chỉ số dẫn xuất từ BCTC 
             * Lấy ra những chỉ số cần thiết trong quá trình tính toán để bind và Data Contract
             */
            foreach (string fi in basicFis)
            {
                DefineValue(indicatorList, fi);
            }
                        
            // Khởi tạo những giá trị dùng trong chức năng filter
            if (isGetFilterData)
            {               
            	basicIndicator.ClosePrice = myMethods.GetTheNewestClosePrice(stockCode);
            	
                basicIndicator.QuickRatio = (basicIndicator.Fi_100 - basicIndicator.Fi_140) / basicIndicator.Fi_310;
                myMethods.InsertIntoFilterDataList(ref resultList, "QuickRatio", "Quick ratio", basicIndicator.QuickRatio);

                basicIndicator.BookValue = (basicIndicator.Fi_400 - basicIndicator.Fi_227) / basicIndicator.Fi_TOS;
                myMethods.InsertIntoFilterDataList(ref resultList, "BookValue", "Book value", basicIndicator.BookValue);

                basicIndicator.EPSBasic = myMethods.GetSumProfitAfterTax(stockCode, currentPeriod) / basicIndicator.Fi_TOS;
                myMethods.InsertIntoFilterDataList(ref resultList, "EPS", "EPS cơ bản", basicIndicator.EPSBasic);

                basicIndicator.PE = (double)(basicIndicator.ClosePrice) / basicIndicator.EPSBasic;
                myMethods.InsertIntoFilterDataList(ref resultList, "PE", "P/E", basicIndicator.PE);

                basicIndicator.Beta = myMethods.CalculateBetaValue(stockCode);
                myMethods.InsertIntoFilterDataList(ref resultList,"Beta", "Beta", basicIndicator.Beta);

                basicIndicator.MarketCap = (double)basicIndicator.ClosePrice * basicIndicator.Fi_TOS;
                myMethods.InsertIntoFilterDataList(ref resultList, "MarketCap", "Giá trị vốn hoá thị trường", basicIndicator.MarketCap);

                basicIndicator.NetProfitMargin = basicIndicator.Fi_60 / basicIndicator.Fi_1;
                myMethods.InsertIntoFilterDataList(ref resultList, "NetProfitMargin", "Hệ số biên lợi nhuận ròng", basicIndicator.NetProfitMargin);                
            }
            else
            {
                basicIndicator.ClosePrice = myMethods.GetTheNewestClosePrice(stockCode);
                myMethods.InsertIntoFiBasicItemList(ref resultList, "Giá đóng cửa", (double)basicIndicator.ClosePrice);

                basicIndicator.QuickRatio = (basicIndicator.Fi_100 - basicIndicator.Fi_140) / basicIndicator.Fi_310;
                myMethods.InsertIntoFiBasicItemList(ref resultList, "Quick ratio", basicIndicator.QuickRatio);

                basicIndicator.ROE = basicIndicator.Fi_60 / basicIndicator.Fi_400 * 100;
                myMethods.InsertIntoFiBasicItemList(ref resultList, "ROE", basicIndicator.ROE);

                basicIndicator.ROA = basicIndicator.Fi_60 / (basicIndicator.Fi_100 + basicIndicator.Fi_200) * 100;
                myMethods.InsertIntoFiBasicItemList(ref resultList, "ROA", basicIndicator.ROA);

                basicIndicator.BookValue = (basicIndicator.Fi_400 - basicIndicator.Fi_227) / basicIndicator.Fi_TOS;
                myMethods.InsertIntoFiBasicItemList(ref resultList, "Book value", basicIndicator.BookValue);

                basicIndicator.PB = (double)(basicIndicator.ClosePrice) / basicIndicator.BookValue;
                myMethods.InsertIntoFiBasicItemList(ref resultList, "P/B", basicIndicator.PB);

                basicIndicator.Max52w = myMethods.GetTheHighestClosePrice_52W(stockCode);
                myMethods.InsertIntoFiBasicItemList(ref resultList, "Giá cao nhất 52 tuần", basicIndicator.Max52w);

                basicIndicator.Min52w = myMethods.GetTheLowestClosePrice_52W(stockCode);
                myMethods.InsertIntoFiBasicItemList(ref resultList, "Giá thấp nhất 52 tuần", basicIndicator.Min52w);

                basicIndicator.EPSBasic = myMethods.GetSumProfitAfterTax(stockCode, currentPeriod) / basicIndicator.Fi_TOS;
                myMethods.InsertIntoFiBasicItemList(ref resultList, "EPS cơ bản", basicIndicator.EPSBasic);

                basicIndicator.PE = (double)(basicIndicator.ClosePrice) / basicIndicator.EPSBasic;
                myMethods.InsertIntoFiBasicItemList(ref resultList, "P/E", basicIndicator.PE);

                basicIndicator.Beta = myMethods.CalculateBetaValue(stockCode);
                myMethods.InsertIntoFiBasicItemList(ref resultList, "Beta", basicIndicator.Beta);

                basicIndicator.FinancialLeverage = 1 + basicIndicator.Fi_300 / basicIndicator.Fi_400;
                myMethods.InsertIntoFiBasicItemList(ref resultList, "Đòn bẩy tài chính", basicIndicator.FinancialLeverage);

                basicIndicator.NetProfitMargin = basicIndicator.Fi_60 / basicIndicator.Fi_1;
                myMethods.InsertIntoFiBasicItemList(ref resultList, "Hệ số biên lợi nhuận ròng", basicIndicator.NetProfitMargin);
            }
            return resultList;

        }

        public List<FinancialRecord> GetFinancialReport(string stockCode)
        {
            List<Period> periodsList = myMethods.GetPeriodsFromDB(stockCode);
            List<FinancialRecord> financialReport = new List<FinancialRecord>();
            FinancialRecord financialRecord = new FinancialRecord();
            List<IndicatorItem> indicatorList;

            bool setTitle = false;
            int noOfValueCol = periodsList.Count;
            int noOfRow;
            //int j = 2;      // insert tiếp vào cột thứ 3 ( title, quý 1, quý 2...)
            int k = 0;      // index của indicatorlist (trong khi setTitle = true)
            foreach (Period period in periodsList)
            {
                indicatorList = myMethods.GetFinancialReport(stockCode, period.Quarter, period.Year);
                noOfRow = indicatorList.Count;

                // Nếu chưa có title, sẽ insert vào cột title [1] và cột quý 1 [2]
                if (!setTitle)
                {
                    foreach (IndicatorItem item in indicatorList)
                    {
                        financialRecord = new FinancialRecord();
                        financialRecord.Title = item.Title;
                        financialRecord.Value.Add(item.Value);
                        financialReport.Add(financialRecord);
                    }
                    setTitle = true;
                }
                // tiếp tục insert Value vào cột 3 trở đi
                else
                {
                    k = 0;
                    for (int i = 0; i < noOfRow; i++)
                    {
                        if (k < noOfRow)
                        {
                            financialReport[i].Value.Add(indicatorList[k].Value);
                            k++;
                        }
                    }
                }
            }
            return financialReport;
        }

        public List<string[]> GetPeriods(string stockCode)
        {
            List<string[]> result = new List<string[]>();

            List<Period> periodsList = myMethods.GetPeriodsFromDB(stockCode);

            foreach(Period period in periodsList)
            {
                string[] newRow = new string[2];
                newRow[0] = period.Quarter;
                newRow[1] = period.Year;
                result.Add(newRow);
            }

            return result;
        }

        public void GetFilterData()
        {
            List<FIItem> filterDataList = this.GetTheBasicIndicators("HNM", "2/2011", true);
            myMethods.InsertToFilterTable(filterDataList);
        }

        // Các chỉ số dẫn xuất từ BCTC indicatorLIst, IndicatorItem
        public void DefineValue(List<string[]> indicatorList, string fiID)
        {
            // tìm kiếm Title và Value dựa trên ID
            indicatorItem = myMethods.FindIndicatorItem(indicatorList, fiID);
            if (indicatorItem != null)
            {
                switch (fiID)
                {
                    case "1":
                        basicIndicator.Fi_1 = indicatorItem.Value;
                        break;
                    case "60":
                        basicIndicator.Fi_60 = indicatorItem.Value;
                        break;
                    case "100":
                        basicIndicator.Fi_100 = indicatorItem.Value;
                        break;
                    case "140":
                        basicIndicator.Fi_140 = indicatorItem.Value;
                        break;
                    case "200":
                        basicIndicator.Fi_200 = indicatorItem.Value;
                        break;
                    case "227":
                        basicIndicator.Fi_227 = indicatorItem.Value;
                        break;
                    case "300":
                        basicIndicator.Fi_300 = indicatorItem.Value;
                        break;
                    case "310":
                        basicIndicator.Fi_310 = indicatorItem.Value;
                        break;
                    case "400":
                        basicIndicator.Fi_400 = indicatorItem.Value;
                        break;
                    case "TOS":
                        basicIndicator.Fi_TOS = indicatorItem.Value;
                        break;
                }
            }
        }
    }
}
