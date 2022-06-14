using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Models;

namespace WebTradeApi.Services
{
    public interface IMarketService
    {
        /// <summary> Update market price.</summary>
        public Task UpdatePriceAsync(Market market, CancellationToken cancellationToken);
    }
}
