using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using StockPriceService;
using System.ServiceModel.Description;
using StockNewsService;
using ForecastService;
using StockMarketService;

namespace StockPriceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Type priceType = typeof(StockPrice);
            Type newsType = typeof(StockNews);
            Type financeType = typeof(FinancialIndicatorService);
            Type forecastType = typeof(ForecastService.ForecastService);

            ServiceHost hostPrice = new ServiceHost(priceType);
            ServiceMetadataBehavior hostPriceBehavior = new ServiceMetadataBehavior();
            hostPriceBehavior.HttpGetEnabled = true;
            hostPriceBehavior.HttpGetUrl = new Uri("http://localhost:90/StockPrice");
            hostPrice.Description.Behaviors.Add(hostPriceBehavior);

            ServiceHost hostNews = new ServiceHost(newsType);
            ServiceMetadataBehavior hostNewsBehavior = new ServiceMetadataBehavior();
            hostNewsBehavior.HttpGetEnabled = true;
            hostNewsBehavior.HttpGetUrl = new Uri("http://localhost:90/StockNews");
            hostNews.Description.Behaviors.Add(hostNewsBehavior);

            ServiceHost hostFinance = new ServiceHost(financeType);
            ServiceMetadataBehavior hostFinanceBehavior = new ServiceMetadataBehavior();
            hostFinanceBehavior.HttpGetEnabled = true;
            hostFinanceBehavior.HttpGetUrl = new Uri("http://localhost:90/StockFinance");
            hostFinance.Description.Behaviors.Add(hostFinanceBehavior);

            ServiceHost hostForecast = new ServiceHost(forecastType);
            ServiceMetadataBehavior hostForecastBehavior = new ServiceMetadataBehavior();
            hostForecastBehavior.HttpGetEnabled = true;
            hostForecastBehavior.HttpGetUrl = new Uri("http://localhost:90/StockForecast");
            hostForecast.Description.Behaviors.Add(hostForecastBehavior);

            using (hostPrice)
            using (hostNews)
            using (hostFinance)
            using (hostForecast)
            {
                Type contractPrice = typeof(IStockPrice);
                Type contractNews = typeof(IStockNews);
                Type contractFinance = typeof(IFinancialIndicatorService);
                Type contractForecast = typeof(IForecastService);

                hostPrice.AddServiceEndpoint(contractPrice, new BasicHttpBinding(), "http://localhost:90/StockPrice");
                hostNews.AddServiceEndpoint(contractNews, new BasicHttpBinding(), "http://localhost:90/StockNews");
                hostFinance.AddServiceEndpoint(contractFinance, new BasicHttpBinding(), "http://localhost:90/StockFinance");
                hostForecast.AddServiceEndpoint(contractForecast, new WSDualHttpBinding(), "http://localhost:90/StockForecast"); 

                hostPrice.Open();
                hostNews.Open();
                hostFinance.Open();
                hostForecast.Open();

                Console.WriteLine("Press <ENTER> to quit");
                Console.ReadLine();
            }
        }
    }
}
