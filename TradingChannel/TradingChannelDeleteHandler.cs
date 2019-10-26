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
    public class TradingChannelDeleteHandler : TradingChannelDeleteHandlerBase  {
        public TradingChannelDeleteHandler(
                BaseRepository<TradingChannel> repo,
                TradingChannelSearchEngine searchEngine,
                IMapperService mapper
                ) : base(repo, searchEngine, mapper)
        {

        }
    }
}
