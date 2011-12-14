using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using StockMarketService;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace OLEDB
{
    class Database
    {
        static MySqlConnection connection = new MySqlConnection("SERVER=localhost;" +
                                                               "DATABASE=stock_db;" +
                                                               "UID=root;" +
                                                               "PASSWORD=westlife;");

        public static List<string[]> Query(string query)
        {
            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> result = new List<string[]>();

            int fieldCount = reader.FieldCount;

            while (reader.Read())
            {
                string[] row = new string[fieldCount];

                for (int i = 0; i < fieldCount; i++)
                {
                    row[i] = reader.GetString(i);
                }

                result.Add(row);
            }

            connection.Close();

            return result;
        }

        public static void InsertToFilterTable(List<FIItem> filterDataList)
        {
            connection.Open();
            string query = "";
            foreach (FIItem item in filterDataList)
            {
                query = "INSERT INTO filter_data (id, title, value) VALUES ('"
                      + item.ID + "', '"
                      + item.Name + "', '"
                      + item.Value + "')";
                MySqlCommand insert = new MySqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }

        }
    }
}
