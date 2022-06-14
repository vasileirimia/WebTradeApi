using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi.Persistece.Repository
{
    public class TradeRepository : ITradeRepository
    {
        private readonly TradeContext _context;

        private readonly IAggregateRepository _aggregatedValuesRepository;
        public TradeRepository(TradeContext context, IAggregateRepository aggregatedValuesRepository)
        {
            _context = context;
            _aggregatedValuesRepository = aggregatedValuesRepository;
        }

        public async Task<IList<TradeDb>> GetTradesAsync(string name, CancellationToken cancellationToken)
        {
            var trades = string.IsNullOrEmpty(name) ?
                await _context.Trades.ToListAsync(cancellationToken).ConfigureAwait(false) :
                await _context.Trades.Where(s => s.TradeBuyer == name).ToListAsync();

            return trades;
        }

        public async Task AddTradeAsync(TradeDb trade, CancellationToken cancellationToken)
        {
            await _context.Trades.AddAsync(trade);

            var portofolio = await _context.Portofolios.SingleOrDefaultAsync(p => p.HolderName == trade.TradeBuyer).ConfigureAwait(false);

            if (portofolio != null)
            {
                trade.Portofolio = portofolio;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTradeAsync(int tradeId, CancellationToken cancellationToken)
        {
            var trade = await _context.Trades.SingleOrDefaultAsync(p => p.TradeId == tradeId).ConfigureAwait(false);

            if (trade != null)
            {
                _context.Trades.Remove(trade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
