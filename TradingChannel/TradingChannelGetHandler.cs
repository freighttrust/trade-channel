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
    public class TradingChannelGetHandler : TradingChannelGetHandlerBase  {
        public TradingChannelGetHandler(
                BaseRepository<TradingChannel> repo,
                IMapperService mapper
                ) : base(repo, mapper)
        {

        }
    }
}
