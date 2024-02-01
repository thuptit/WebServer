using System;
using System.Net;
using System.Net.Sockets;
using WebServer.Abstractions;

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
        public IServiceProvider ServiceProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static WebApplicationBuilder CreateWebBuilder() => new WebApplicationBuilder();

        public RequestDelegate Build()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Start()
        {
            var tcpConnection = new TcpListener(IPAddress.Parse(_host), _port);
            tcpConnection.Start();
            while (true)
            {
                var client = await tcpConnection.AcceptTcpClientAsync();
                //TODO: parser socket to context
                var stream = client.GetStream();
                var content = stream.GetSequenceBytes();
                stream.Close();
            }
        }

        public Task Stop(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
    }
}
