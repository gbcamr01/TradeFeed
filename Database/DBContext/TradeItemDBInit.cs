using Database.Examples;
using RedBurnTradeFeed.Models;
using System.Linq;

namespace RedBurnTradeFeed.DBContext
{
    public static class TradeItemDBInit
    {
        public static void Initialize(TradeItemDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.TradeItems.Any()) return;

            var tradeitems = DBStartupExamples.tradeitems;


            foreach (TradeItem ti in tradeitems)
            {
                context.TradeItems.Add(ti);
            }
            context.SaveChanges();

            var tradedata = DBStartupExamples.trades;


            foreach (TradeData td in tradedata)
            {
                context.Trades.Add(td);
            }
            context.SaveChanges();


        }
    }
}
