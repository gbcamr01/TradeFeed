using RedBurnTradeFeed.Constants;



namespace RedBurnTradeFeed.Models
{
    public class TradeItem
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public Side Side { get; set; }     //(buy, sell, or short)
        public string Ticker { get; set; }
        public decimal LastPrice { get; set; }
        public TradeItem() { }
    }
}