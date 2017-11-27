using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BettingApp.BettingApp.Core
{
    class Export
    {
        internal static void Output(string outputMethod, IOrderedEnumerable<ReportData> sortedReportResult)
        {
            if (outputMethod == "XML")
                Export.ReportToXml(sortedReportResult);
            else if (outputMethod == "Console")
                Export.ReportToConsole(sortedReportResult);
            else Console.WriteLine("Invalid Output Method refenced in App.Config file");

        }
        public static void ReportToConsole(IOrderedEnumerable<ReportData> result)
        {
            Console.WriteLine("Selection Name |Currency |No Of Bets |Total Stakes     |Total Payout  ");

            foreach (ReportData item in result)
            {
                Console.WriteLine("{0}    |  {1}    | {2}         | {3} {4}         | {3} {5}",
                    item.SelectionId,
                    item.Currency,
                    item.NoOfBets,
                    Utilities.Currency(item.Currency),
                    item.TotalStake,
                    item.TotalPayout);
            }

        }

        internal static void ReportToXml(IOrderedEnumerable<ReportData> reportResult)
        {

            List<ReportData> y = reportResult.Cast<ReportData>().ToList();

            DataContractSerializer s = new DataContractSerializer(typeof(List<ReportData>));
            using (FileStream fs = File.Open("myTest" + typeof(List<ReportData>).Name + ".xml", FileMode.Create))
            {
                Console.WriteLine("Testing for type: {0}", typeof(List<ReportData>));
                s.WriteObject(fs, y);
            }
        }
    }
}
