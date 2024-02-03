using WebServer.Abstractions;
using WebServer.Abstractions.Contexts;

namespace WebServer;

public class RequestDispatcher(IServiceProvider serviceProvider, byte[] bytes, string verions) : IRequestDispatcher
{
    private readonly IProtocolHandlerFactory _handlerFactory = serviceProvider.GetService(typeof(IProtocolHandlerFactory)) as IProtocolHandlerFactory ?? throw new NullReferenceException();

    public HttpContext Process()
    {
        var protocolHandler = _handlerFactory.Create(verions);
        protocolHandler.Handle(bytes);
        return null;
    }
}