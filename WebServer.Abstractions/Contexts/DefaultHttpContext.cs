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
        public DefaultHttpContext(HttpRequest request) : base(request)
        {
        }

        public override HttpRequest Request { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public override HttpResponse Response { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ClaimsPrincipal Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ISession Session { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
