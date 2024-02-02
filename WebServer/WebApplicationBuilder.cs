using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
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
            this._webApplication.Services.AddSingleton<IHttpComponentParser, HttpRequestParser>();
            return this;
        }

        internal WebApplicationBuilder AddProtocolHandlerFactory()
        {
            this._webApplication.Services.AddSingleton<IProtocolHandlerFactory, ProtocolHandlerFactory>();
            return this;
        }

        internal WebApplicationBuilder AddProtocolHandler()
        {
            _webApplication.Services.AddSingleton<IProtocolHandler, Http11ProtocolHandler>();
            return this;
        }

        internal WebApplicationBuilder AddHttpContextAccessor()
        {
            _webApplication.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            return this;
        }
        public WebApplication Build() => _webApplication;
    }
}
