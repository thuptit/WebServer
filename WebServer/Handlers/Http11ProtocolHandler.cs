using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions;
using WebServer.Abstractions.Contexts;
using WebServer.Abstractions.Contexts.Requests;
using WebServer.Abstractions.HttpProtocols;

namespace WebServer.Handlers
{
    public class Http11ProtocolHandler(IServiceProvider serviceProvider, IHttpComponentParser httpComponentParser) : IProtocolHandler
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        private readonly IHttpComponentParser _httpParser = httpComponentParser ?? throw new ArgumentNullException(nameof(httpComponentParser));

        public async Task Handle(byte[] buffer)
        {
            var httpRequest = GetHttpRequest(buffer);
            var httpContext = new HttpContext(httpRequest);
            // through middleware

            //through controller

            //received httpcontext
        }

        private HttpRequest GetHttpRequest(byte[] bytes)
        {
            var content = Encoding.UTF8.GetString(bytes);
            return _httpParser.ParserHttpRequest(content);
        }
    }
}
