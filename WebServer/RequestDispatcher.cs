using WebServer.Abstractions;
using WebServer.Abstractions.Contexts;

namespace WebServer;

public class RequestDispatcher(IServiceProvider serviceProvider, byte[] bytes, string verions) : IRequestDispatcher
{
    private readonly IServiceProvider _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    private byte[] _bytes = bytes;
    private readonly IProtocolHandlerFactory _handlerFactory = serviceProvider.GetService(typeof(IProtocolHandlerFactory)) as IProtocolHandlerFactory ?? throw new NullReferenceException();

    public HttpContext Process()
    {
        var protocolHandler = _handlerFactory.Create(verions);
        protocolHandler.Handle(bytes);
        return null;
    }
}