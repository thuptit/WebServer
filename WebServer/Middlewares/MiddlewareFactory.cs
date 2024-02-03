using Microsoft.Extensions.DependencyInjection;
using WebServer.Abstractions;

namespace WebServer.Middlewares;

public class MiddlewareFactory(IServiceProvider serviceProvider) : IMiddlewareFactory
{
    public IMiddleware? Create(Type middlewareType)
    {
        return serviceProvider.GetRequiredService(middlewareType) as IMiddleware;
    }

    public void Release(IMiddleware middleware)
    {
    }
}