using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Models;
using WebTradeApi.Persistece.Entities;
using WebTradeApi.Persistece.Repository;

namespace WebTradeApi.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;

        private readonly IMapper _mapper;

        public TradeService(ITradeRepository tradeRepository, IMapper mapper)
        {
            _tradeRepository = tradeRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IList<Trade>> GetTradesAsync(string name, CancellationToken cancellationToken)
        {
            var tradesDb = await _tradeRepository.GetTradesAsync(name, cancellationToken).ConfigureAwait(false);

            var trades = _mapper.Map<IList<Trade>>(tradesDb);

            return trades;
        }

        /// <inheritdoc />
        public async Task AddTradeAsync(Trade trade, CancellationToken cancellationToken)
        {
            var newTrade = _mapper.Map<TradeDb>(trade);

            await _tradeRepository.AddTradeAsync(newTrade, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task DeleteTradeAsync(int tradeId, CancellationToken cancellationToken)
        {
            await _tradeRepository.DeleteTradeAsync(tradeId, cancellationToken).ConfigureAwait(false);
        }
    }
}
