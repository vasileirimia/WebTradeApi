using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Models;
using WebTradeApi.Services;

namespace WebTradeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTradesAsync([FromQuery] string name, CancellationToken cancellationToken)
        {
            var trades = await _tradeService.GetTradesAsync(name, cancellationToken).ConfigureAwait(false);

            return Ok(trades);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTradeAsync([FromBody] Trade trade, CancellationToken cancellationToken)
        {
            await _tradeService.AddTradeAsync(trade, cancellationToken).ConfigureAwait(false);

            return NoContent();
        }

        [HttpDelete("{tradeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteTradesAsync([FromRoute] int tradeId, CancellationToken cancellationToken)
        {
            await _tradeService.DeleteTradeAsync(tradeId, cancellationToken).ConfigureAwait(false);

            return NoContent();
        }
    }
}
