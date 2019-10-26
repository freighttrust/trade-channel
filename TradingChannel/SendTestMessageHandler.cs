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
    public partial class SendTestMessageRequest : IRequest<TradingChannelServiceModel>
    {

    }

    public class SendTestMessageHandler : SendTestMessageHandlerBase  {
        public SendTestMessageHandler(
                BaseRepository<TradingChannel> repo,
                TradingChannelSearchEngine searchEngine,
                IMapperService mapper,
                IMediator mediator
                ) : base(repo, searchEngine, mapper, mediator)
        {

        }

        protected override async Task Handle(SendTestMessageRequest request, TradingChannel model)
        {

        }
    }
}
