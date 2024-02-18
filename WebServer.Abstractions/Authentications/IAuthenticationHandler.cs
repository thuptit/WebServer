namespace WebServer.Abstractions.Authentications;

public interface IAuthenticationHandler
{
    Task<bool> Handle();
}