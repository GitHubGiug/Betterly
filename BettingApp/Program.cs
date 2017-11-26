using System;
using System.Collections.Generic;
using BettingApp.BettingApp.Core;
using System.Net.Http;
using System.Configuration;

namespace BettingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bet> stats = new List<Bet>();

            var betList = Utilities.ReadCSV(stats);


            string currencyValue = ConfigurationManager.AppSettings["CurrencyOutput"];
            betList = Utilities.CurrencyConversion(betList, currencyValue);

            var reportResult = Utilities.GroupReport(betList);




            string OrderByValue = ConfigurationManager.AppSettings["OrderBy"];
            var sortedReportResult = Utilities.SortReport(reportResult,OrderByValue);




            string OutputMethod = ConfigurationManager.AppSettings["OutputMethod"];
            Utilities.Output(OutputMethod, sortedReportResult);



            Console.ReadKey();
        }

        async static void GetRequest()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("http://www.google.com.pk"))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        Console.WriteLine(mycontent);
                    }
                }
            }
        }
    }



}
