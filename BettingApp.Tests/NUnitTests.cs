using BettingApp.BettingApp.Core;
using BettingApp.BettingApp.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingApp.Tests
{
    [TestFixture]
    class NUnitTests
    {
        [Test]
        public void TestCalculateListPayout()
        {
            List<Bet> testList = new List<Bet> { new Bet
            {
                Stake = 1.1,
                Price = 2.2
            } };

            testList = Utilities.CalculateListPayout(testList);

            var expectedResult = testList.FirstOrDefault().Payout;

            Assert.That(expectedResult, Is.EqualTo(1.1*2.2));
        }


        [Test]
        public void TestCurrencyConversion()
        {
            List<Bet> testList = new List<Bet> { new Bet
            {
                Currency = "EUR",
                Stake = 1.1,
                Price = 2.2
            } };

            testList = Utilities.CurrencyConversion(testList, "GBP");

            double expectedResult = testList.FirstOrDefault().Price;

            var rate =BettingApp.Model.Currency.Rate;
            Assert.That(expectedResult, Is.EqualTo(2.2/rate));
        }
    }
}
