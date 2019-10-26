using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlockArray.Core;
using BlockArray.Core.Data;
using BlockArray.Core.Mapping;
using BlockArray.Core.Mongo;
using BlockArray.Core.Services;
using BlockArray.ServiceModel;
using Microsoft.Extensions.DependencyInjection;
namespace FreightTrust.Modules.TradingChannel
{
    public class TradingChannelMapper : BaseTradingChannelMapper
    {
        private readonly IUserContextProvider _userContext;

        public TradingChannelMapper(IServiceProvider serviceProvider, IUserContextProvider userContext)
        {
            _userContext = userContext;
            ServiceProvider = serviceProvider;
        }

        public override void MapMore(TradingChannel source, TradingChannelServiceModel target)
        {
            target.Uri = $"http://localhost:5000/api/{_userContext.GetCompanyId()}/AS2";
            
            // Additional Mappings ...
        }
    }
}
