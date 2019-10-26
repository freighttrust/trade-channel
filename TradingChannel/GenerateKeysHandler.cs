using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlockArray.Core.Data;
using BlockArray.Core.Mapping;
using BlockArray.Core.Services;
using BlockArray.Model.Mongo;
using BlockArray.ServiceModel;
using MediatR;
using Selfsigned;

namespace FreightTrust.Modules.TradingChannel
{
    public partial class GenerateKeysRequest : IRequest<TradingChannelServiceModel>
    {

    }

    public class GenerateKeysHandler : GenerateKeysHandlerBase  {
        public GenerateKeysHandler(
                BaseRepository<TradingChannel> repo,
                TradingChannelSearchEngine searchEngine,
                IMapperService mapper,
                IMediator mediator
                ) : base(repo, searchEngine, mapper, mediator)
        {

        }

        protected override async Task Handle(GenerateKeysRequest request, TradingChannel model)
        {
            var result = Certificates.GenerateCertificate(model.Name);
            var builder = new StringBuilder();
            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(Convert.ToBase64String(result.Result.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine("-----END CERTIFICATE-----");
            model.PublicKey = builder.ToString();
            model.PrivateKey = Convert.ToBase64String(result.Result.Export(X509ContentType.Pkcs12), Base64FormattingOptions.InsertLineBreaks);
            
            
            //result.Result.Export(X509ContentType.Pkcs7)
            //var cert = Certificates.Get(result.PrivateKeyPem, result.PublicKeyPem,model.Name);
        }
    }
}
