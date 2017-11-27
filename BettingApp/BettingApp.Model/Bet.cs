using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BettingApp
{
    [XmlRoot(ElementName = "bet")]

    public class Bet
    {
        [XmlElement("BetId")]
        public string BetId { get; set; }
        [XmlElement("betTimestamp")]
        public long BetTimestamp { get; set; }
        [XmlElement("selectionId")]
        public long SelectionId { get; set; }
        [XmlElement("selectionName")]
        public string SelectionName { get; set; }
        [XmlElement("stake")]
        public double Stake { get; set; }
        [XmlElement("price")]
        public double Price { get; set; }
        [XmlElement("currency")]
        public string Currency { get; set; }
        public double Payout { get; set; }

        public void CalculatePayout()
        {
            this.Payout = Stake * Price;
        }
    }
}
