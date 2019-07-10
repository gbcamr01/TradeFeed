using Database.Examples;
using Microsoft.EntityFrameworkCore;
using RedBurnTradeFeed.Models;

namespace RedBurnTradeFeed.DBContext
{
    public class TradeItemDBContext : DbContext
    {
        public TradeItemDBContext(DbContextOptions<TradeItemDBContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<TradeItem> TradeItems { get; set; }
        public DbSet<TradeData> Trades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeItem>().HasData(DBStartupExamples.tradeitems);
            modelBuilder.Entity<TradeItem>().ToTable("TradeItem");
            modelBuilder.Entity<TradeData>().HasData(DBStartupExamples.trades);
            modelBuilder.Entity<TradeData>().ToTable("TradeData");
        }
    }
}
