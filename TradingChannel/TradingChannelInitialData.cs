using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlockArray.Core.Data;
using BlockArray.Core.Mapping;
using BlockArray.Core.Mongo;
using BlockArray.Core.Services;
using BlockArray.ServiceModel;
using MongoDB.Bson.Serialization.Attributes;
using BlockArray.Harbor.Authorization;
using MongoDB.Driver;
namespace FreightTrust.Modules.TradingChannel
{
    public partial class TradingChannelInitialData : IModelInitialData<TradingChannel>
    {
        public IEnumerable<TradingChannel> Get(IMongoDatabase db) {
            yield break;
        }
    }

}
