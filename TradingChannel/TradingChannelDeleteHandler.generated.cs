using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BlockArray.Core.Data;
using BlockArray.Core.Mapping;
using BlockArray.Model.Mongo;
using BlockArray.ServiceModel;
using MediatR;

namespace FreightTrust.Modules.TradingChannel
{
    public class DeleteTradingChannelRequest : IRequest
    {
        public string Id { get; set; }
    }
    public class TradingChannelDeleteHandlerBase : IRequestHandler<DeleteTradingChannelRequest>
    {
        public BaseRepository<TradingChannel> Repo { get; }
        public TradingChannelSearchEngine SearchEngine { get; }
        public IMapperService Mapper { get; }

        public TradingChannelDeleteHandlerBase(
            BaseRepository<TradingChannel> repo,
            TradingChannelSearchEngine searchEngine,
            IMapperService mapper
            )
        {
            Repo = repo;
            SearchEngine = searchEngine;
            Mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTradingChannelRequest request, CancellationToken cancellationToken)
        {
            await Repo.Remove(await Repo.Find(request.Id));
            return Unit.Value;
        }

        protected virtual Expression<Func<TradingChannel, bool>> GetFilter()
        {
            return null;
        }
    }
}
