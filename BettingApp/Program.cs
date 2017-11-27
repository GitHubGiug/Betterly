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

            string currencyValue = ConfigurationManager.AppSettings["CurrencyOutput"];
            string OrderByValue = ConfigurationManager.AppSettings["OrderBy"];
            string OutputMethod = ConfigurationManager.AppSettings["OutputMethod"];


            //Import Data
            var betList = Import.ReadCSV(stats);

            //Calculate Payout
            betList = Utilities.CalculateListPayout(betList);


            //Convert Currency if required 
            betList = Utilities.CurrencyConversion(betList, currencyValue);

            //Group list of bets
            var groupReportResult = Utilities.GroupReport(betList);


            //Sort list of bets
            var sortedReportResult = Utilities.SortReport(groupReportResult, OrderByValue);

            //Display List as per congif in App.config
            Export.Output(OutputMethod, sortedReportResult);



            Console.ReadLine();
        }

    }



}
