using System.Security.Claims;
using WebServer.Abstractions.Contexts.Requests;
using WebServer.Abstractions.Contexts.Responses;

namespace WebServer.Abstractions.Contexts
{
    public class DefaultHttpContext : HttpContext
    {
        public DefaultHttpContext(HttpRequest request, IServiceProvider serviceProvider)
        {
            Request = request;
            RequestServices = serviceProvider;
        }

        public override HttpRequest Request { get; }
        public override HttpResponse Response { get; set; } = new();
        public override ClaimsPrincipal Users { get ; set; }
        public override ISession Session { get ; set; }
        public override IServiceProvider RequestServices { get; } = null!;
        public override object GetEndpoint()
        {
            return Request.HttpUrl.Path;
        }
    }
}
