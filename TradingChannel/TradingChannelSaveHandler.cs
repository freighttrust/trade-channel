using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BlockArray.Core.Data;
using BlockArray.Core.Mapping;
using BlockArray.Core.Services;
using BlockArray.Model.Mongo;
using BlockArray.ServiceModel;
using MediatR;

namespace FreightTrust.Modules.TradingChannel
{
    public class TradingChannelSaveHandler : TradingChannelSaveHandlerBase  {
        public TradingChannelSaveHandler(
                BaseRepository<TradingChannel> repo,
                IMapperService mapper
                ) : base(repo, mapper)
        {

        }
        protected override async Task Apply( TradingChannelServiceModel source , TradingChannel target )
        {
            if (source == null) return;
            // Do Additional saving things here
        }
    }
}
