using System;
using System.Net;
using System.Net.Sockets;
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

        public IServiceProvider ServiceProvider => Services.BuildServiceProvider();

        public IServiceCollection Services { get; }
        public static WebApplicationBuilder CreateWebBuilder() => new WebApplicationBuilder()
            .AddProtocolHandler()
            .AddHttpRequestParser()
            .AddProtocolHandlerFactory();

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
                var stream = client.GetStream();
                var requestDispatcher = new RequestDispatcher(ServiceProvider, stream.GetBytes(), _protocol);
                requestDispatcher.Process();
                stream.Close();
            }
        }

        public async Task Stop(CancellationToken cancellationToken = default)
        {
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            //TODO:
            Start().GetAwaiter().GetResult();
        }
        
        public RequestDelegate Build()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
