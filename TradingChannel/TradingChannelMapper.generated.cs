using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlockArray.Core.Data;
using BlockArray.Core.Mapping;
using BlockArray.Core.Mongo;
using BlockArray.Core.Services;
using BlockArray.ServiceModel;
using Microsoft.Extensions.DependencyInjection;
namespace FreightTrust.Modules.TradingChannel
{
    public static class TradingChannelExtensions {
        public static TradingChannelServiceModel MapTradingChannel(this IMapperService mapper, TradingChannel model, TradingChannelServiceModel serviceModel = null) {
            serviceModel = serviceModel ?? new TradingChannelServiceModel();
            mapper.MapTo<TradingChannel,TradingChannelServiceModel>(model,serviceModel);
            return serviceModel;
        }
    }
    public abstract class BaseTradingChannelMapper : IMapper<TradingChannel, TradingChannelServiceModel>, IFidelityMapper
    {
        public int Fidelity { get; set; }
        public IServiceProvider ServiceProvider { get;set; }

        public virtual TradingChannelServiceModel Map(TradingChannel source, TradingChannelServiceModel target)
        {
            if (source == null) return target;
            var mapper = ServiceProvider.GetService<IMapperService>();
            target.Id = source.Id;

            
            
            target.Name = source.Name;
            
            
            target.Uri = source.Uri;
            
            
            target.PrivateKey = source.PrivateKey;
            
            
            target.PublicKey = source.PublicKey;
            
            
            target.Password = source.Password;
            
            MapMore( source, target );
            return target;
        }
        public abstract void MapMore(TradingChannel source, TradingChannelServiceModel target);

        
        
        
        
        
        
        
        
        
        
        
    }

}
