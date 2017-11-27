using BettingApp.BettingApp.Core;
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
    }
}
