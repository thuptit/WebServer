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
    public abstract class HttpContext
    {
        public HttpContext(HttpRequest request)
        {
            Request = request;
        }
        public abstract HttpRequest Request { get; init; }
        public abstract HttpResponse Response { get; set; }
        public abstract ClaimsPrincipal Users { get; set; }
        public abstract ISession Session { get; set; }
    }
}
