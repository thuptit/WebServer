using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions;
using WebServer.Abstractions.HttpProtocols;

namespace WebServer.Handlers
{
    public class Http11ProtocolHandler(IServiceProvider serviceProvider, IHttpComponentParser httpComponentParser) : IProtocolHandler
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        private readonly IHttpComponentParser _httpParser = httpComponentParser ?? throw new ArgumentNullException(nameof(httpComponentParser));

    }
}
