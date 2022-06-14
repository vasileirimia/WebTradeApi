using Microsoft.EntityFrameworkCore;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi.Persistece
{
    public class TradeContext : DbContext
    {
        public TradeContext(DbContextOptions<TradeContext> options) : base(options)
        {
        }

        public DbSet<PortofolioDb> Portofolios { get; set; }

        public DbSet<TradeDb> Trades { get; set; }

        public DbSet<MarketDb> MarketUpdates { get; set; }
    }
}
