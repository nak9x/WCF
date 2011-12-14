using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StockPriceService
{
    public class StockPrice : IStockPrice
    {
        public List<string[]> GetPrice(string ticker, int limit)
        {
            string query = "select date, open, high, low, close, volume from stock_price where stock_code='" + ticker + "' order by date desc limit " + limit.ToString();
            List<string[]> records = Database.Query(query);

            for (int i = 0; i < records.Count - 1; i++)
            {
                double change = Math.Round(100 * ((Convert.ToDouble(records[i][4]) - Convert.ToDouble(records[i + 1][4])) / Convert.ToDouble(records[i + 1][4])), 2);
                string[] newRow = new string[7];

                newRow[0] = records[i][0];
                newRow[1] = records[i][1];
                newRow[2] = records[i][2];
                newRow[3] = records[i][3];
                newRow[4] = records[i][4];
                newRow[5] = records[i][5];
                newRow[6] = change.ToString();

                records[i] = newRow;
            }

            // Columns: 0-date, 1-close, 2-volume, 3-change
            return records;
        }

        public List<string[]> GetMostTraded()
        {
            string query = "select * from (select stock_code, open, high, low, close, volume from stock_price order by date desc) as temp where stock_code not in ('^VNINDEX', '^HASTC') group by stock_code order by volume desc limit 5";
            return Database.Query(query);
        }

        public List<string[]> GetMostIncrease()
        {
            string query = "select distinct stock_code from month_price where stock_code not in('^VNINDEX', '^HASTC')";
            List<string[]> tickers = Database.Query(query);

            query = "select * from (select * from stock_price order by date desc) as temp where stock_code not in ('^VNINDEX', '^HASTC') group by stock_code";
            List<string[]> records = Database.Query(query);

            int count = 0;

            foreach (string[] i in tickers)
            {
                string ticker = i[0];

                query = "select * from stock_price where stock_code='" + ticker + "' order by date desc limit 2";

                List<string[]> temp = Database.Query(query);

                double yesterday = Convert.ToDouble(temp[0][6]);
                double today = Convert.ToDouble(temp[1][6]);

                double roc = Math.Round(((today - yesterday) / yesterday) * 100, 2);

                string[] newRow = new string[9];

                newRow[0] = temp[0][0];
                newRow[1] = temp[0][1];
                newRow[2] = temp[0][2];
                newRow[3] = temp[0][3];
                newRow[4] = temp[0][4];
                newRow[5] = temp[0][5];
                newRow[6] = temp[0][6];
                newRow[7] = temp[0][7];
                newRow[8] = roc.ToString();

                records[count] = newRow;

                count++;
            }

            RemoveNegativeROC(ref records);
            SortBy(8, ref records, "desc");

            // Columns: 0-id, 1-ticker, 2-date, 3-open, 4-high, 5-low, 6-close, 7-volume, 8-rate of change
            return records;
        }

        public List<string[]> GetMostDecrease()
        {
            string query = "select distinct stock_code from month_price where stock_code not in('^VNINDEX', '^HASTC')";
            List<string[]> tickers = Database.Query(query);

            query = "select * from (select * from stock_price order by date desc) as temp where stock_code not in ('^VNINDEX', '^HASTC') group by stock_code";
            List<string[]> records = Database.Query(query);

            int count = 0;

            foreach (string[] i in tickers)
            {
                string ticker = i[0];

                query = "select * from stock_price where stock_code='" + ticker + "' order by date desc limit 2";

                List<string[]> temp = Database.Query(query);

                double yesterday = Convert.ToDouble(temp[0][6]);
                double today = Convert.ToDouble(temp[1][6]);

                double roc = Math.Round(((today - yesterday) / yesterday) * 100, 2);

                string[] newRow = new string[9];

                newRow[0] = temp[0][0];
                newRow[1] = temp[0][1];
                newRow[2] = temp[0][2];
                newRow[3] = temp[0][3];
                newRow[4] = temp[0][4];
                newRow[5] = temp[0][5];
                newRow[6] = temp[0][6];
                newRow[7] = temp[0][7];
                newRow[8] = roc.ToString();

                records[count] = newRow;

                count++;
            }

            RemovePositiveROC(ref records);
            SortBy(8, ref records, "asc");

            return records;
        }

        private void SortBy(int index, ref List<string[]> input, string type)
        {
            switch(type)
            {
                case "desc":
                    for (int pass = 1; pass < input.Count; pass++)
                        for (int i = 0; i < input.Count - 1; i++)
                            if (Convert.ToDouble(input[i][index]) < Convert.ToDouble(input[i + 1][index]))
                            {
                                string[] temp = input[i];
                                input[i] = input[i + 1];
                                input[i + 1] = temp;
                            }
                    break;

                case "asc":
                    for (int pass = 1; pass < input.Count; pass++)
                        for (int i = 0; i < input.Count - 1; i++)
                            if (Convert.ToDouble(input[i][index]) > Convert.ToDouble(input[i + 1][index]))
                            {
                                string[] temp = input[i];
                                input[i] = input[i + 1];
                                input[i + 1] = temp;
                            }
                    break;
            }
        }

        private void RemoveNegativeROC(ref List<string[]> input)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (Convert.ToDouble(input[i][8]) <= 0)
                    indexes.Add(i);
            }

            for (int i = 0; i < indexes.Count; i++)
            {
                if (i > 0)
                    indexes[i] -= i;

                input.RemoveAt(indexes[i]);
            }
        }

        private void RemovePositiveROC(ref List<string[]> input)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (Convert.ToDouble(input[i][8]) >= 0)
                    indexes.Add(i);
            }

            for (int i = 0; i < indexes.Count; i++)
            {
                if (i > 0)
                    indexes[i] -= i;

                input.RemoveAt(indexes[i]);
            }
        }
    }
}
