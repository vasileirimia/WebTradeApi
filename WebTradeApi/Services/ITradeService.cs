using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Models;

namespace WebTradeApi.Services
{
    /// <summary> Contract for trading services. </summary>
    public interface ITradeService
    {
        /// <summary> Get all Trades.</summary>
        public Task<IList<Trade>> GetTradesAsync(string name, CancellationToken cancellationToken);

        /// <summary> Add new Trade.</summary>
        public Task AddTradeAsync(Trade trade, CancellationToken cancellationToken);

        /// <summary> Delete a Trade.</summary>
        public Task DeleteTradeAsync(int tradeId, CancellationToken cancellationToken);
    }
}
