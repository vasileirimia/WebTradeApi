using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi.Persistece.Repository
{
    public class MarketRepository : IMarketRepository
    {
        private readonly TradeContext _context;

        public MarketRepository(TradeContext context)
        {
            _context = context;
        }

        public async Task UpdatePriceAsync(MarketDb market, CancellationToken cancellationToken)
        {
            var marketItem = await _context.MarketUpdates.FindAsync(market.SecurityCode).ConfigureAwait(false);

            if (marketItem != null && market.MarketPrice != marketItem.MarketPrice)
            {
                marketItem.MarketPrice = market.MarketPrice;
                _context.MarketUpdates.Update(marketItem);
            }

            await _context.SaveChangesAsync();
        }
    }
}
