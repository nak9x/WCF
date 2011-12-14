using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;

namespace StockPriceService
{
    class Database
    {
        static OdbcConnection connection = new OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};" +
                                                                "SERVER=localhost;" +
                                                                "DATABASE=stock_db;" +
                                                                "UID=root;" +
                                                                "PASSWORD=westlife;" +
                                                                "OPTION=3");

        public static List<string[]> Query(string query)
        {
            connection.Open();

            OdbcCommand command = new OdbcCommand(query, connection);
            OdbcDataReader reader = command.ExecuteReader();

            List<string[]> result = new List<string[]>();

            int fieldCount = reader.FieldCount;

            while (reader.Read())
            {
                string[] row = new string[fieldCount];

                for (int i = 0; i < fieldCount; i++)
                    row[i] = reader.GetString(i);

                result.Add(row);
            }

            connection.Close();

            return result;
        }
    }
}
