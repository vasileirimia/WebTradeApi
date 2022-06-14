using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Models;
using WebTradeApi.Services;

namespace WebTradeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly IMarketService _marketService;

        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePriceAsync([FromBody] Market market, CancellationToken cancellationToken)
        {
            await _marketService.UpdatePriceAsync(market, cancellationToken).ConfigureAwait(false);

            return NoContent();
        }
    }
}
