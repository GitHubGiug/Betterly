namespace BettingApp
{
    public class ReportData
    {
        public string SelectionId { get; set; }
        public string Currency { get; set; }
        internal Bet FirstElement { get; set; }
        public int NoOfBets { get; set; }
        public double TotalStake { get; set; }
        public double TotalPayout { get; set; }


    }
}