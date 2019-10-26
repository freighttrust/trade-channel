using System.Threading.Tasks;
using BlockArray.Core.Services;
using BlockArray.ServiceModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Annotations;
using MediatR;
namespace FreightTrust.Modules.TradingChannel
{
    public class BaseTradingChannelController : Controller
    {
        public IMediator Mediator { get; }

        public BaseTradingChannelController( IMediator mediator )
        {
            Mediator = mediator;
        }
        
        [HttpPost("generateKeys")]
        [Produces(typeof(TradingChannelServiceModel))]
        [SwaggerOperation("generateKeys")]
        public async Task<IActionResult> GenerateKeys( [FromBody] GenerateKeysRequest request = null)
        {
            return Ok(await Mediator.Send(request));
        }
        

        

        
        [HttpPost("getTradingChannels")]
        [Produces(typeof(QueryResult<TradingChannelServiceModel>))]
        [SwaggerOperation("getTradingchannels")]
        public async Task<IActionResult> GetTradingChannels( [FromBody] TradingChannelQueryRequest request = null)
        {
            return Ok(await Mediator.Send(request));
        }
        

        
        [HttpGet("getTradingChannel")]
        [Produces(typeof(TradingChannelServiceModel))]
        [SwaggerOperation("getTradingChannel")]
        public async Task<IActionResult> GetTradingChannel(string id)
        {
            return Ok(await Mediator.Send(new GetTradingChannelRequest() { Id = id }));
        }
        

        
        [HttpPost("saveTradingChannel")]
        [Produces(typeof(TradingChannelServiceModel))]
        [SwaggerOperation("saveTradingChannel")]
        public async Task<IActionResult> SaveTradingChannel([FromBody] TradingChannelServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await Mediator.Send(new SaveTradingChannelRequest() {
                ServiceModel = model
            }));
        }
        
        
        [HttpPost("deleteTradingChannel")]
        [SwaggerOperation("deleteTradingChannel")]
        public async Task<IActionResult> DeleteTradingChannel(string id)
        {
            await Mediator.Send(new DeleteTradingChannelRequest() { Id = id });
            return Ok();
        }
        
    }
}
