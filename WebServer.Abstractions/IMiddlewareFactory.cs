namespace WebServer.Abstractions;

public interface IMiddlewareFactory
{
    IMiddleware? Create(Type middlewareType);
    void Release(IMiddleware middleware);
}