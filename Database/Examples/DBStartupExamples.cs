using RedBurnTradeFeed.Constants;

using RedBurnTradeFeed.Models;

namespace Database.Examples
{
    public static class DBStartupExamples
    {
        public static TradeData[] trades = new TradeData[]
            {
                new TradeData{Id=1,Amount = 100,Currency="CAD",Description="",OrderInstruction="day order",OrderTransmission="broker",Qty=100000,TradeType=TradeType.limit},
                new TradeData{Id=2,Amount = 200,Currency="EUR",Description="",OrderInstruction="day order",OrderTransmission="ATF",Qty=200000,TradeType=TradeType.market},
                new TradeData{Id=3,Amount = 300,Currency="GBP",Description="",OrderInstruction="kill",OrderTransmission="ECN",Qty=300000,TradeType=TradeType.stop},
                new TradeData{Id=4,Amount = 400,Currency="CAD",Description="",OrderInstruction="day order",OrderTransmission="broker",Qty=400000,TradeType=TradeType.limit},
                new TradeData{Id=5,Amount = 500,Currency="ZAR",Description="",OrderInstruction="day order",OrderTransmission="broker",Qty=500000,TradeType=TradeType.market},
                new TradeData{Id=6,Amount = 600,Currency="GBP",Description="",OrderInstruction="kill",OrderTransmission="ECN",Qty=600000,TradeType=TradeType.stop},
                new TradeData{Id=7,Amount = 700,Currency="USD",Description="",OrderInstruction="fill",OrderTransmission="broker",Qty=700000,TradeType=TradeType.limit}
            };

        public static TradeItem[] tradeitems = new TradeItem[]
           {
                    new TradeItem{Id = 1,LastPrice=1.11M,Side=Side.buy,Status=Status.New,Ticker="RTR"},
                    new TradeItem{Id = 2,LastPrice=1.12M,Side=Side.buy,Status=Status.New,Ticker="LLOYDS"},
                    new TradeItem{Id = 3,LastPrice=1.13M,Side=Side.buy,Status=Status.New,Ticker="DEUET"},
                    new TradeItem{Id = 4,LastPrice=1.14M,Side=Side.buy,Status=Status.New,Ticker="BARC"},
                    new TradeItem{Id = 5,LastPrice=1.15M,Side=Side.buy,Status=Status.New,Ticker="REDB"},
            };

    }
}
