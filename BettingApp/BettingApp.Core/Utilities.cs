using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BettingApp.BettingApp.Core
{
    public static class Utilities
    {



        internal static List<Bet> CurrencyConversion(List<Bet> reportResult, string currencyValue)
        {
            if (reportResult == null)
                return reportResult;


            try
            {
                if (currencyValue == "EUR")
                {

                    foreach (Bet result in reportResult)
                    {

                        if (result.Currency != "EUR")
                        {
                            result.Price = result.Price * Model.Currency.Rate;
                            result.Currency = "EUR";
                        }

                    }
                    return reportResult;
                }
                else if (currencyValue == "GBP")
                {
                    foreach (Bet result in reportResult)
                    {

                        if (result.Currency != "GBP")
                        {
                            result.Price = result.Price / Model.Currency.Rate;
                            result.Currency = "GBP";
                        }
                    }
                    return reportResult;

                }
            }
            catch (Exception)
            {

                throw;
            }

            return reportResult;

        }

        public static string Currency(string a)
        {
            if (a == "EUR")
                return "E";
            else if (a == "GBP")
                return "£";
            else
                return "?";

        }


        internal static IEnumerable<ReportData> GroupReport(IEnumerable<Bet> betList)
        {

            var groupedReport = (from bet in betList

                                 group bet by new { bet.SelectionName, bet.Currency }

                        into grouping

                                 select new ReportData
                                 {
                                     SelectionId = grouping.FirstOrDefault().SelectionName,
                                     Currency = grouping.FirstOrDefault().Currency,
                                     NoOfBets = grouping.Count(),
                                     TotalStake = grouping.Sum(p => p.Stake),
                                     TotalPayout = grouping.Sum(p =>p.Payout),
                                 });
            return groupedReport;
        }

        public static IOrderedEnumerable<ReportData> SortReport(IEnumerable<ReportData> groupedReport, string OrderByValue)
        {
            var propertyInfo = typeof(ReportData).GetProperty(OrderByValue);
            var sortedReport = groupedReport
                         .OrderByDescending(x => propertyInfo.GetValue(x, null));
            return sortedReport;
        }

        internal static List<Bet> CalculateListPayout(List<Bet> betList)
        {
            foreach (Bet bet in betList)
            {
                bet.CalculatePayout();
            }
            return betList;
        }
    }
}


