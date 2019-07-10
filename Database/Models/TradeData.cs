using System;
using System.Collections.Generic;
using RedBurnTradeFeed.Constants;

namespace RedBurnTradeFeed.Models
{
    public class TradeData
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public TradeType TradeType { get; set; } //(e.g., market, limit, stop, etc.)
        public string OrderInstruction { get; set; } //(e.g., day order, fill or kill, good-till-canceled, etc.)
        public string OrderTransmission { get; set; } //(broker, ECN, ATC, etc.)
        public string Description { get; set; }
        public ICollection<TradeItem> TradeItems { get; set; }
        public TradeData() { }
    }
}