using Microsoft.EntityFrameworkCore;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi.Persistece
{
    public class TradeContext : DbContext
    {
        public TradeContext(DbContextOptions<TradeContext> options) : base(options)
        {
        }

        /// <summary> List of all Portofolios.</summary>
        public DbSet<PortofolioDb> Portofolios { get; set; }

        /// <summary> List of all Trades.</summary>
        public DbSet<TradeDb> Trades { get; set; }

        /// <summary> List of all MarketUpdates.</summary>
        public DbSet<MarketDb> MarketUpdates { get; set; }
    }
}
