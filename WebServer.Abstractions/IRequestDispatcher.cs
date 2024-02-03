using WebServer.Abstractions.Contexts;

namespace WebServer.Abstractions;

public interface IRequestDispatcher
{
    Task<HttpContext> Process();
}