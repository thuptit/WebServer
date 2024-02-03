using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
        public override HttpResponse Response { get ; set ; }
        public override ClaimsPrincipal Users { get ; set; }
        public override ISession Session { get ; set; }
        public override IServiceProvider RequestServices { get; }
    }
}
