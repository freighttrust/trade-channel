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
namespace FreightTrust.Modules.TradingChannel
{
    [BsonIgnoreExtraElements]
    public partial class TradingChannel : BaseMongoDocument
    {
        
        public System.String Name {get;set;}
        
        public System.String Uri {get;set;}
        
        public System.String PrivateKey {get;set;}
        
        public System.String PublicKey {get;set;}
        
        public System.String Password {get;set;}
        
    }

}
