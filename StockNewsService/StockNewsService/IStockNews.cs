using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StockNewsService
{
    [ServiceContract]
    public interface IStockNews
    {
        [OperationContract]
        List<string[]> GetNews(string ticker, int limit);

        [OperationContract]
        List<string[]> GetExpertAnalysis(string ticker, int limit);
    }
}
