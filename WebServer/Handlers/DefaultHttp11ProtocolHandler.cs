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
    public class DefaultHttp11ProtocolHandler(IServiceProvider serviceProvider, IHttpComponentParser httpComponentParser, IHttpContextAccessor httpContextAccessor) 
        : IProtocolHandler
    {
        public Task<HttpContext> StartProcessAsync(byte[] buffer)
        {
            var httpRequest = GetHttpRequest(buffer);
            httpContextAccessor.HttpContext = new DefaultHttpContext(httpRequest, serviceProvider);
            return Task.FromResult(httpContextAccessor.HttpContext);
        }

        public async Task<HttpContext> ProcessPipelineAsync(RequestDelegate middleware)
        {
             await middleware.Invoke(httpContextAccessor.HttpContext);
             return httpContextAccessor.HttpContext;
        }

        public async Task ProcessResponseAsync()
        {

        }

        private HttpRequest GetHttpRequest(byte[] bytes)
        {
            var content = Encoding.UTF8.GetString(bytes);
            return httpComponentParser.ParserHttpRequest(content);
        }
    }
}
