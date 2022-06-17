using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Services;

namespace WebTradeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortofolioController : ControllerBase
    {
        private readonly IPortofolioService _portofolioService;

        public PortofolioController(IPortofolioService portofolioService)
        {
            _portofolioService = portofolioService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPortofoliosAsync(CancellationToken cancellationToken)
        {
            var portofolios = await _portofolioService.GetPortofoliosAsync(cancellationToken).ConfigureAwait(false);

            return Ok(portofolios);
        }
    }
}
