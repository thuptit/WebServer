using WebServer.Abstractions.Authentications;
using WebServer.Abstractions.Contexts;

namespace WebServer.Authentications;

public class DefaultAuthenticationHandler(IHttpContextAccessor _httpContextAccessor) : IAuthenticationHandler
{
    public Task<bool> Handle()
    {
        var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

        //TODO check valid token from header

        return Task.FromResult(true);
    }
}