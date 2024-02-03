using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions;
using WebServer.Abstractions.Contexts;
using WebServer.Abstractions.HttpProtocols;

namespace WebServer.Handlers
{
    public class DefaultProtocolHandlerFactory(IServiceProvider serviceProvider) : IProtocolHandlerFactory
    {
        public IProtocolHandler Create(string version)
        {
            if(version == HttpVersions.Http11)
            {
                return new DefaultHttp11ProtocolHandler(
                        serviceProvider,
                        (IHttpComponentParser)serviceProvider.GetService(typeof(IHttpComponentParser)),
                        (IHttpContextAccessor)serviceProvider.GetService(typeof(IHttpContextAccessor))
                    );
            }
            throw new NotSupportedException(nameof(version));
        }
    }
}
