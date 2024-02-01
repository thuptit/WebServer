using WebServer.Abstractions.Contexts;

namespace WebServer.Abstractions;

public interface IRequestDispatcher
{
    HttpContext Process();
}