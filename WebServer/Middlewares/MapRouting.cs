using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions;
using WebServer.Abstractions.Contexts;

namespace WebServer.Middlewares
{
    public class MapRouting : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next, CancellationToken cancellationToken = default)
        {
            //TODO: get url to map controller by convention
            //need to convention define convention
            //get meta-data from MapRouteAttribute

        }
    }
}
