using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Models;

namespace WebTradeApi.Services
{
    public interface IPortofolioService
    {
        /// <summary> Get all Portofolios.</summary>
        public Task<IList<Portofolio>> GetPortofoliosAsync(CancellationToken cancellationToken);
    }
}
