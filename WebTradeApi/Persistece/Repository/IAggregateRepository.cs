using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi.Persistece.Repository
{
    /// <summary> Builder pattern. </summary>
    public interface IAggregateRepository
    {
        public Task<PortofolioDb> BuildPortofolio(PortofolioDb portofolioDb, DbSet<MarketDb> marketUpdates);
    }
}
