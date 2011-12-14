using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ForecastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IForecastServiceCallback))]
    public interface IForecastService
    {
        [OperationContract(IsOneWay = true)]
        void GetForecastData(string ticker, int limit);

        // TODO: Add your service operations here
    }

    public interface IForecastServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendResult(List<Forecast> result);
    }

    public class ForecastServiceClient : System.ServiceModel.DuplexClientBase<IForecastService>, IForecastService
    {
        public ForecastServiceClient(InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress) :
            base(callbackInstance, binding, remoteAddress)
        { 
        
        }

        public void GetForecastData(string ticker, int limit)
        {
            base.Channel.GetForecastData(ticker, limit);
        }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations
    [DataContract]
    public class Forecast
    {
        string stock;
        double forecast;
        double limit50;
        double limit95;

        [DataMember]
        public string Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        [DataMember]
        public double ForecastVal
        {
            get { return forecast; }
            set { forecast = value; }
        }

        [DataMember]
        public double Limit50
        {
            get { return limit50; }
            set { limit50 = value; }
        }

        [DataMember]
        public double Limit95
        {
            get { return limit95; }
            set { limit95 = value; }
        }
    }
}
