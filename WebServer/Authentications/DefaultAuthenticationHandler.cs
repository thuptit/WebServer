using WebServer.Abstractions.Authentications;

namespace WebServer.Authentications;

public class DefaultAuthenticationHandler : IAuthenticationHandler
{
    public Task<bool> Handle()
    {
        throw new NotImplementedException();
    }
}