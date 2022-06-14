using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi.Persistece.Repository
{
    public class PortofolioRepository : IPortofolioRepository
    {
        private readonly TradeContext _context;

        private readonly IAggregateRepository _aggregateRepository;

        public PortofolioRepository(TradeContext context, IAggregateRepository aggregatedValuesRepository)
        {
            _context = context;
            _aggregateRepository = aggregatedValuesRepository;
        }

        public async Task<IList<PortofolioDb>> GetPortofoliosAsync(CancellationToken cancellationToken)
        {
            var portofolios = _context.Portofolios.ForEachAsync(p =>
            {
                _aggregateRepository.BuildPortofolio(p, _context.MarketUpdates);
            });

            _ = await _context.SaveChangesAsync();

            return _context.Portofolios.ToList();
        }
    }
}
