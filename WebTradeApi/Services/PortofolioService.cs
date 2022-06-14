using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Models;
using WebTradeApi.Persistece.Repository;

namespace WebTradeApi.Services
{
    public class PortofolioService : IPortofolioService
    {
        private readonly IPortofolioRepository _portofolioRepository;

        private readonly IMapper _mapper;

        public PortofolioService(IPortofolioRepository portofolioRepository, IMapper mapper)
        {
            _portofolioRepository = portofolioRepository;
            _mapper = mapper;
        }

        public async Task<IList<Portofolio>> GetPortofoliosAsync(CancellationToken cancellationToken)
        {
            var portofoliosDb = await _portofolioRepository.GetPortofoliosAsync(cancellationToken).ConfigureAwait(false);

            var portofolios = _mapper.Map<IList<Portofolio>>(portofoliosDb);

            return portofolios;
        }
    }
}
