using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingApp
{
    class Bet
    {

        public string BetId { get; set; }
        public long BetTimestamp { get; set; }
        public long SelectionId { get; set; }
        public string SelectionName { get; set; }
        public double Stake { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
    }
}
