using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace StockMarketService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFinancialIndicatorService
    {       
        // TODO: Add your service operations here
        [OperationContract]
        List<FIItem> GetTheBasicIndicators(string stockCode, string currentPeriod, bool isGetFilterData);

        [OperationContract]
        List<FinancialRecord> GetFinancialReport(string stockCode);

        [OperationContract]
        List<string[]> GetPeriods(string stockCode);

        [OperationContract]
        void GetFilterData();
    }

    [DataContract]
    public class FIItem
    {
        string id;
        string name;
        double dbvalue;

        [DataMember]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public double Value
        {
            get { return dbvalue; }
            set { dbvalue = value; }
        }   
    }

    [DataContract]
    public class FinancialRecord
    {
        string title;
        List<double> dbvalueList = new List<double>();

        [DataMember]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [DataMember]
        public List<double> Value
        {
            get { return dbvalueList; }
            set { dbvalueList = value; }
        }
    }    
}
