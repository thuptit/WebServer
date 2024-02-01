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
    public class HttpContext
    {
        public HttpContext(HttpRequest request)
        {
            Request = request;
        }
        public HttpRequest Request { get; init; }
        public HttpResponse Response { get; set; }
        public ClaimsPrincipal Users { get; set; }
        public ISession Session { get; set; }
    }
}
