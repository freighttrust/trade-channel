using System;
using System.Collections.Generic;
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
        public string Id { get; set; }

        
    }
     public partial class SendTestMessageEvent : INotification
        {
            public string Id { get; set; }

            public TradingChannelServiceModel ServiceModel { get;set; }

            public TradingChannel Model { get;set; }
        }
    public abstract class SendTestMessageHandlerBase : IRequestHandler<SendTestMessageRequest,TradingChannelServiceModel>
    {
        public BaseRepository<TradingChannel> Repo { get; }
        public TradingChannelSearchEngine SearchEngine { get; }
        public IMapperService Mapper { get; }
        public IMediator Mediator { get; }

        public SendTestMessageHandlerBase(
            BaseRepository<TradingChannel> repo,
            TradingChannelSearchEngine searchEngine,
            IMapperService mapper,
            IMediator mediator
            )
        {
            Repo = repo;
            SearchEngine = searchEngine;
            Mapper = mapper;
            Mediator = mediator;
        }

        public async Task<TradingChannelServiceModel> Handle(SendTestMessageRequest request, CancellationToken cancellationToken)
        {
            var item = await Repo.Find(request.Id);
            await Handle(request, item);
            await Repo.Save(item);
            var serviceModel = Mapper.MapTo<TradingChannel,TradingChannelServiceModel>(item,2);
            await Mediator.Publish(FillEvent(new SendTestMessageEvent() { Id = request.Id, Model = item, ServiceModel = serviceModel }));
            return serviceModel;
        }

        protected abstract Task Handle(SendTestMessageRequest request, TradingChannel model);
        protected virtual SendTestMessageEvent FillEvent(SendTestMessageEvent evt) {
            return evt;
        }
    }
}
