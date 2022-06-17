using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Models;
using WebTradeApi.Persistece.Entities;
using WebTradeApi.Persistece.Repository;

namespace WebTradeApi.Services
{
    public class MarketService : IMarketService
    {
        private readonly IMarketRepository _marketRepository;

        private readonly IMapper _mapper;

        public MarketService(IMarketRepository marketRepository, IMapper mapper)
        {
            _marketRepository = marketRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task UpdatePriceAsync(Market market, CancellationToken cancellationToken)
        {
            var marketUpdate = _mapper.Map<MarketDb>(market);

            await _marketRepository.UpdatePriceAsync(marketUpdate, cancellationToken).ConfigureAwait(false);
        }
    }
}
