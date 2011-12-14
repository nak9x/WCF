using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StockNewsService
{
    public class StockNews : IStockNews
    {
        public List<string[]> GetNews(string ticker, int limit)
        {
            string query = "";

            switch(ticker)
            {
                case "":
                    query = "select * from stock_news order by pub_date desc limit " + limit.ToString();
                    break;

                default:
                    List<string[]> tickers = Database.Query("select distinct stock_code from month_price");

                    bool found = false;

                    foreach (string[] row in tickers)
                    {
                        if (row[0] == ticker)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        return new List<string[]>();

                    query = "select * from stock_news where title like '%" + ticker + "%' or description like '%" + ticker + "%' order by pub_date desc limit " + limit.ToString();
                    break;
            }

            return Database.Query(query);
        }

        public List<string[]> GetExpertAnalysis(string ticker, int limit)
        {
            string query = "";

            switch (ticker)
            {
                case "":
                    query = "select * from stock_expert_analysis order by pub_date desc limit " + limit.ToString();
                    break;

                default:
                    List<string[]> tickers = Database.Query("select distinct stock_code from month_price");

                    bool found = false;

                    foreach (string[] row in tickers)
                    {
                        if (row[0] == ticker)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        return new List<string[]>();

                    query = "select * from stock_expert_analysis where title like '" + ticker + "%' order by pub_date desc limit " + limit.ToString();
                    break;
            }

            return Database.Query(query);
        }
    }
}
