using System.Linq;
// <copyright file="UtilitiesTest.cs">Copyright ©  2017</copyright>
using System;
using System.Collections.Generic;
using BettingApp;
using BettingApp.BettingApp.Core;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingApp.BettingApp.Core.Tests
{
    /// <summary>This class contains parameterized unit tests for Utilities</summary>
    [PexClass(typeof(Utilities))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class UtilitiesTest
    {
        /// <summary>Test stub for CurrencyConversion(List`1&lt;Bet&gt;, String)</summary>
        [PexMethod]
        internal List<Bet> CurrencyConversionTest(List<Bet> reportResult, string currencyValue)
        {
            List<Bet> result = Utilities.CurrencyConversion(reportResult, currencyValue);
            return result;
            // TODO: add assertions to method UtilitiesTest.CurrencyConversionTest(List`1<Bet>, String)
        }

        /// <summary>Test stub for Currency(String)</summary>
        [PexMethod]
        public string CurrencyTest(string a)
        {

            string result = Utilities.Currency(a);
            return result;
            // TODO: add assertions to method UtilitiesTest.CurrencyTest(String)

        }

        /// <summary>Test stub for GroupReport(IEnumerable`1&lt;Bet&gt;)</summary>
        [PexMethod]
        internal IEnumerable<ReportData> GroupReportTest(IEnumerable<Bet> betList)
        {
            IEnumerable<ReportData> result = Utilities.GroupReport(betList);
            return result;
            // TODO: add assertions to method UtilitiesTest.GroupReportTest(IEnumerable`1<Bet>)
        }

        /// <summary>Test stub for SortReport(IEnumerable`1&lt;ReportData&gt;, String)</summary>
        [PexMethod]
        public IOrderedEnumerable<ReportData> SortReportTest(IEnumerable<ReportData> groupedReport, string OrderByValue)
        {
            IOrderedEnumerable<ReportData> result = Utilities.SortReport(groupedReport, OrderByValue);
            return result;
            // TODO: add assertions to method UtilitiesTest.SortReportTest(IEnumerable`1<ReportData>, String)
        }

        /// <summary>Test stub for Output(String, IOrderedEnumerable`1&lt;ReportData&gt;)</summary>
        [PexMethod]
        internal void OutputTest(string outputMethod, IOrderedEnumerable<ReportData> sortedReportResult)
        {
            Export.Output(outputMethod, sortedReportResult);
            // TODO: add assertions to method UtilitiesTest.OutputTest(String, IOrderedEnumerable`1<ReportData>)
        }

        /// <summary>Test stub for CalculateListPayout(List`1&lt;Bet&gt;)</summary>
        [PexMethod]
        internal List<Bet> CalculateListPayoutTest(List<Bet> betList)
        {
            List<Bet> result = Utilities.CalculateListPayout(betList);
            return result;
            // TODO: add assertions to method UtilitiesTest.CalculateListPayoutTest(List`1<Bet>)
        }
    }
}
