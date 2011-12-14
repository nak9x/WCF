using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace ForecastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ForecastService : IForecastService
    {
        List<Forecast> result = new List<Forecast>();
        int past = 5;

        public void GetForecastData(string ticker, int limit)
        {
            string query_model = "SELECT model_id FROM stock_model WHERE stock_code = '" + ticker + "'";
            List<string[]> model = Database.Query(query_model);

            if (model.Count <= 0)
                return;
            string model_id = model[0][0];
            
            string query = "SELECT value, confi_50, confi_95 FROM model_forecast WHERE model_id='" +
                            model_id + "' AND `order` > " + past.ToString()
                            + " ORDER BY `order` ASC LIMIT " + limit.ToString();
            List<string[]> records = Database.Query(query);

            result.Clear();

            for (int i = 0; i < records.Count; i++)
            {
                Forecast newForecast = new Forecast();
                newForecast.Stock = ticker;
                newForecast.ForecastVal = Convert.ToDouble(records[i][0]);
                newForecast.Limit50 = Convert.ToDouble(records[i][1]);
                newForecast.Limit95 = Convert.ToDouble(records[i][2]);
                
                result.Add(newForecast);
            }
            Thread.Sleep(2000);

            Callback.SendResult(result);
        }

        IForecastServiceCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IForecastServiceCallback>();
            }
        }
    }
}
