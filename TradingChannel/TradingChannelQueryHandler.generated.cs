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
    public partial class TradingChannelQueryRequest : IRequest<QueryResult<TradingChannelServiceModel>>
    {
        public Query Query { get; set; }
    }
    public class TradingChannelQueryHandlerBase : IRequestHandler<TradingChannelQueryRequest,QueryResult<TradingChannelServiceModel>>
    {
        public BaseRepository<TradingChannel> Repo { get; }
        public TradingChannelSearchEngine SearchEngine { get; }
        public IMapperService Mapper { get; }

        public TradingChannelQueryHandlerBase(
            BaseRepository<TradingChannel> repo,
            TradingChannelSearchEngine searchEngine,
            IMapperService mapper
            )
        {
            Repo = repo;
            SearchEngine = searchEngine;
            Mapper = mapper;
        }

        protected async Task<QueryResult<TradingChannel>> QueryResult(Query query)
        {
            var filter = GetFilter();
            QueryResult<TradingChannel> results = null;
            if (filter != null)
            {
                results = await SearchEngine.Search(Repo.Get().Where(filter), query);
            }
            else
            {
                results = await SearchEngine.Search(Repo.Get(), query);
            }
            return results;
        }
        public virtual async Task<QueryResult<TradingChannelServiceModel>> Handle(TradingChannelQueryRequest request, CancellationToken cancellationToken)
        {
            return await Query(request.Query);
        }

        public virtual async Task<QueryResult<TradingChannelServiceModel>> Query(Query query = null)
        {
            var results = await QueryResult(query);
            var mapper = this.Mapper.Mapper<TradingChannel, TradingChannelServiceModel>(query.Fidelity);



            var result = new QueryResult<TradingChannelServiceModel>()
            {
                Result = new List<TradingChannelServiceModel>(),
                Total = results.Total
            };
            if (results.Result != null) {
                foreach (var item in results.Result) {
                    var mapped = mapper.Map(item, new TradingChannelServiceModel());
                    result.Result.Add(mapped);
                    await OnMap(item, mapped);
                }
            }
            return result;
        }
        public virtual async Task OnMap(TradingChannel model, TradingChannelServiceModel serviceModel) {

        }
        protected virtual Expression<Func<TradingChannel, bool>> GetFilter()
        {
            return null;
        }
    }
}
