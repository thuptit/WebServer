using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebServer.Abstractions;
using WebServer.Abstractions.Contexts;
using WebServer.Handlers;
using WebServer.Parsers;

namespace WebServer
{
    public sealed class WebApplicationBuilder
    {
        private WebApplication _webApplication= null!;
        public WebApplicationBuilder() => _webApplication = new();
        internal WebApplicationBuilder AddHttpRequestParser()
        {
            this._webApplication.Services.TryAddSingleton<IHttpComponentParser, DefaultHttpRequestParser>();
            return this;
        }

        internal WebApplicationBuilder AddProtocolHandlerFactory()
        {
            this._webApplication.Services.TryAddSingleton<IProtocolHandlerFactory, DefaultProtocolHandlerFactory>();
            return this;
        }

        internal WebApplicationBuilder AddProtocolHandler()
        {
            _webApplication.Services.TryAddSingleton<IProtocolHandler, DefaultHttp11ProtocolHandler>();
            return this;
        }

        internal WebApplicationBuilder AddHttpContextAccessor()
        {
            _webApplication.Services.TryAddSingleton<IHttpContextAccessor, DefaultHttpContextAccessor>();
            return this;
        }
        public WebApplication Build() => _webApplication;
    }
}
