using WebServer.Abstractions;
using WebServer.Abstractions.Contexts;

namespace WebServer;

public class RequestDispatcher(IServiceProvider serviceProvider, byte[] bytes, string verions, RequestDelegate middleware) : IRequestDispatcher
{
    private readonly IProtocolHandlerFactory _handlerFactory = serviceProvider.GetService(typeof(IProtocolHandlerFactory)) as IProtocolHandlerFactory ?? throw new NullReferenceException();

    public async Task<HttpContext> Process()
    {
        var protocolHandler = _handlerFactory.Create(verions);
        await protocolHandler.StartProcessAsync(bytes);
        var httpContext = await protocolHandler.ProcessPipelineAsync(middleware);
        return httpContext;
    }
}