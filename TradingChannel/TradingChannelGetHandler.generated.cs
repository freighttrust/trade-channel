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
    public partial class GetTradingChannelRequest : IRequest<TradingChannelServiceModel>
    {
        public string Id { get; set; }
    }
    public class TradingChannelGetHandlerBase : IRequestHandler<GetTradingChannelRequest,TradingChannelServiceModel>
    {
        public BaseRepository<TradingChannel> Repo { get; }
        public IMapperService Mapper { get; }

        public TradingChannelGetHandlerBase(
            BaseRepository<TradingChannel> repo,
            IMapperService mapper
            )
        {
            Repo = repo;
            Mapper = mapper;
        }

        public virtual async Task<TradingChannelServiceModel> Handle(GetTradingChannelRequest request, CancellationToken cancellationToken)
        {
            return Mapper.MapTo<TradingChannel,TradingChannelServiceModel>(await Repo.Find(request.Id),2);
        }

        protected virtual Expression<Func<TradingChannel, bool>> GetFilter()
        {
            return null;
        }
    }
}
