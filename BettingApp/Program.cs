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

            var betList = Import.ReadCSV(stats);

            betList = Utilities.CalculateListPayout(betList);



            string currencyValue = ConfigurationManager.AppSettings["CurrencyOutput"];
            betList = Utilities.CurrencyConversion(betList, currencyValue);

            var groupReportResult = Utilities.GroupReport(betList);




            string OrderByValue = ConfigurationManager.AppSettings["OrderBy"];
            var sortedReportResult = Utilities.SortReport(groupReportResult, OrderByValue);




            string OutputMethod = ConfigurationManager.AppSettings["OutputMethod"];
            Export.Output(OutputMethod, sortedReportResult);



            Console.ReadLine();
        }

    }



}
