﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WebServer.Abstractions;
using WebServer.Abstractions.HttpProtocols;
using WebServer.Parsers;

namespace WebServer
{
    public sealed class WebApplication : IServer, IApplicationBuilder, IEndpointRouteBuilder
    {
        /// <summary>
        /// default = 5000 if cannot get port config from appsettings.{environment}.json
        /// </summary>
        private int _port = 5000;
        /// <summary>
        /// default = 5000 if cannot get host config from appsettings.{environment}.json
        /// </summary>
        private string _host = "127.0.0.1";

        /// <summary>
        /// HTTP/1.1 is default if not set
        /// </summary>
        private string _protocol = HttpVersions.Http11;
        
        public IServiceProvider ApplicationServices => Services.BuildServiceProvider();

        public IServiceCollection Services { get; }

        public RequestDelegate Pipeline => BuildMiddleware();

        private List<Func<RequestDelegate, RequestDelegate>> _middlewares = new();
        public static WebApplicationBuilder CreateWebBuilder() => new WebApplicationBuilder()
            .AddProtocolHandler()
            .AddHttpRequestParser()
            .AddProtocolHandlerFactory()
            .AddHttpContextAccessor()
            .AddMiddlewareFactory();

        public WebApplication()
        {
            Services = new ServiceCollection();
        }
        public async Task Start()
        {
            var tcpConnection = new TcpListener(IPAddress.Parse(_host), _port);
            tcpConnection.Start();
            while (true)
            {
                var client = await tcpConnection.AcceptTcpClientAsync();
                using (var stream = client.GetStream())
                {
                    var requestDispatcher = new RequestDispatcher(ApplicationServices, stream.GetBytes(), _protocol, Pipeline);
                    var httpContext = await requestDispatcher.Process();
                    var response = "HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\nHello from the server!";
                    var responseData = Encoding.ASCII.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);
                    await stream.FlushAsync();
                }
            }
        }

        public async Task Stop(CancellationToken cancellationToken = default)
        {
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }

        public void Run()
        {
            Start().GetAwaiter().GetResult();
        }
        
        private RequestDelegate BuildMiddleware()
        {
            var requestDelegate = (RequestDelegate)(context =>
            {
                context.Response.StatusCode = 404;
                return Task.CompletedTask;
            });
            for(int i = this._middlewares.Count - 1; i >= 0; i--)
            {
                requestDelegate = _middlewares[i](requestDelegate);
            }
            return requestDelegate; 
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
