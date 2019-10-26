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
    public partial class SaveTradingChannelRequest : IRequest<TradingChannelServiceModel>
    {
        public TradingChannelServiceModel ServiceModel { get; set; }
    }
    public class TradingChannelSaveHandlerBase : IRequestHandler<SaveTradingChannelRequest,TradingChannelServiceModel>
    {
        public BaseRepository<TradingChannel> Repo { get; }
        public IMapperService Mapper { get; }

        public TradingChannelSaveHandlerBase(
            BaseRepository<TradingChannel> repo,
            IMapperService mapper
            )
        {
            Repo = repo;
            Mapper = mapper;
        }

        public virtual async Task<TradingChannelServiceModel> Handle(SaveTradingChannelRequest request, CancellationToken cancellationToken)
        {
            TradingChannel target = null;
            if (string.IsNullOrEmpty(request.ServiceModel.Id))
            {
                // new
                target = new TradingChannel();
            }
            else
            {
                target = await Repo.Find(request.ServiceModel.Id);
            }

            if (target == null)
            {
                throw new Exception("Could not save the shipment with that id.  It was not found.");
            }
            var source = request.ServiceModel;
            target.Id = source.Id;
            
            
            target.Name = source.Name;
            
            
            
            target.Uri = source.Uri;
            
            
            
            target.PrivateKey = source.PrivateKey;
            
            
            
            target.PublicKey = source.PublicKey;
            
            
            
            target.Password = source.Password;
            
            
            await Apply(request.ServiceModel, target);
            // Save it
            await Repo.Save(target);
            return this.Mapper.MapTo<TradingChannel, TradingChannelServiceModel>(target);
        }
        protected virtual async Task Apply(TradingChannelServiceModel source , TradingChannel target )
        {

        }
        protected virtual Expression<Func<TradingChannel, bool>> GetFilter()
        {
            return null;
        }
    }
}
