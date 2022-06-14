using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi.Persistece.Repository
{
    /// <summary> Contract for Portofolio services. </summary>
    public interface IPortofolioRepository
    {
        /// <summary> Get all Portofolios.</summary>
        public Task<IList<PortofolioDb>> GetPortofoliosAsync(CancellationToken cancellationToken);
    }
}
