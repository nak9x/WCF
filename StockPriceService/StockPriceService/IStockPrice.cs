using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StockPriceService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStockPrice
    {
        [OperationContract]
        List<string[]> GetPrice(string ticker, int limit);

        [OperationContract]
        List<string[]> GetMostTraded();

        [OperationContract]
        List<string[]> GetMostIncrease();

        [OperationContract]
        List<string[]> GetMostDecrease();
    }
}
