﻿using System;
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

namespace BettingApp.BettingApp.Core
{
    public static class Utilities
    {
        internal static List<Bet> ReadCSV(List<Bet> stats)
        {

            ConnectionStringSettings csv = ConfigurationManager.ConnectionStrings["csv"];

            using (OleDbConnection cn = new OleDbConnection(csv.ConnectionString))
            {
                cn.Open();
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Bet_Data.csv]";
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        int betId = reader.GetOrdinal("betId");
                        int betTimestamp = reader.GetOrdinal("betTimestamp");
                        int selectionId = reader.GetOrdinal("selectionId");
                        int selectionName = reader.GetOrdinal("selectionName");
                        int stake = reader.GetOrdinal("stake");
                        int price = reader.GetOrdinal("price");
                        int currency = reader.GetOrdinal("currency");

                        foreach (DbDataRecord record in reader)
                        {
                            stats.Add(new Bet
                            {
                                BetId = record.GetString(betId),
                                BetTimestamp = (long)record.GetDouble(betTimestamp),
                                SelectionId = record.GetInt32(selectionId),
                                SelectionName = record.GetString(selectionName),
                                Stake = record.GetDouble(stake),
                                Price = record.GetDouble(price),
                                Currency = record.GetString(currency)

                            });
                        }
                    }
                }
            }
            return stats;
        }

        internal static List<Bet> CurrencyConversion(List<Bet> reportResult, string currencyValue)
        {
            if (currencyValue == "EUR")
            {

                foreach (Bet result in reportResult)
                {

                    if (result.Currency != "EUR")
                    {                        result.Price = result.Price/ Model.Currency.Rate;
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
                        result.Price = result.Price * Model.Currency.Rate;
                        result.Currency = "GBP";
                    }
                }
                return reportResult;

            }

            return reportResult;
        
    }

    public static string Currency(string a)
    {
        if (a == "EUR")
            return "€";
        else
            return "£";
    }


    internal static IEnumerable<ReportData> GroupReport(IEnumerable<Bet> betList)
    {
        var propertyInfo = typeof(Bet).GetProperty("SelectionId");

        var d = (from bet in betList

                 group bet by new { bet.SelectionName ,bet.Currency}
                    into grouping
                 select new ReportData
                 {
                     FirstElement = grouping.FirstOrDefault(),
                     NoOfBets = grouping.Count(),
                     TotalStake = grouping.Sum(p => p.Stake),
                     TotalPayout = grouping.Sum(p => p.Stake) * grouping.Sum(p => p.Price),
                 });
        return d;
    }

    public static IOrderedEnumerable<ReportData> SortReport(IEnumerable<ReportData> betList, string OrderByValue)
    {
        var propertyInfo = typeof(ReportData).GetProperty(OrderByValue);
        var d = betList
                     .OrderByDescending(x => propertyInfo.GetValue(x, null));
        return d;
    }

    internal static void Output(string outputMethod, IOrderedEnumerable<ReportData> sortedReportResult)
    {
        if (outputMethod == "XML")
            Utilities.ReportToXml(sortedReportResult);
        else if (outputMethod == "Console")
            Utilities.ReportToConsole(sortedReportResult);
        else Console.WriteLine("Invalid Output Method refenced in App.Config file");

    }


    public static void ReportToConsole(IOrderedEnumerable<ReportData> result)
    {
        Console.WriteLine("Selection Name |Currency |No Of Bets |Total Stakes     |Total Payout  ");

        foreach (ReportData item in result)
        {
            Console.WriteLine("{0}    |  {1}    | {2}         | {3}{4}         | {3} {5}",
                item.FirstElement.SelectionName,
                item.FirstElement.Currency,
                item.NoOfBets,
                Currency(item.FirstElement.Currency),
                item.TotalStake,
                item.TotalPayout);
        }

    }

    internal static void ReportToXml(IOrderedEnumerable<ReportData> reportResult)
    {
        DataContractSerializer s = new DataContractSerializer(typeof(List<ReportData>));
        using (FileStream fs = File.Open("test" + typeof(List<ReportData>).Name + ".xml", FileMode.Create))
        {
            Console.WriteLine("Testing for type: {0}", typeof(List<ReportData>));
            s.WriteObject(fs, reportResult);
        }
    }
}
}

