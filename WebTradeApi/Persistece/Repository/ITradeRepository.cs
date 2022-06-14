using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi.Persistece.Repository
{
    /// <summary> Contract for Trade services. </summary>
    public interface ITradeRepository
    {
        /// <summary> Get all Trades.</summary>
        public Task<IList<TradeDb>> GetTradesAsync(string name, CancellationToken cancellationToken);

        /// <summary> Add new Trade.</summary>
        public Task AddTradeAsync(TradeDb trade, CancellationToken cancellationToken);

        /// <summary> Delete a Trade.</summary>
        public Task DeleteTradeAsync(int tradeId, CancellationToken cancellationToken);
    }
}
