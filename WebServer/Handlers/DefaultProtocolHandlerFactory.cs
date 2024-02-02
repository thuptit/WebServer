using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions;
using WebServer.Abstractions.HttpProtocols;

namespace WebServer.Handlers
{
    public class DefaultProtocolHandlerFactory(IServiceProvider serviceProvider) : IProtocolHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        public IProtocolHandler Create(string version)
        {
            if(version == HttpVersions.Http11)
            {
                return new DefaultHttp11ProtocolHandler(
                        serviceProvider,
                        (IHttpComponentParser)serviceProvider.GetService(typeof(IHttpComponentParser))
                    );
            }
            throw new NotSupportedException(nameof(version));
        }
    }
}
