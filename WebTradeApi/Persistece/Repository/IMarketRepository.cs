using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi.Persistece.Repository
{
    public interface IMarketRepository
    {
        /// <summary> Update market price.</summary>
        public Task UpdatePriceAsync(MarketDb market, CancellationToken cancellationToken);
    }
}
