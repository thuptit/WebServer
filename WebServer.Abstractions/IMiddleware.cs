using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions.Contexts;

namespace WebServer.Abstractions
{
    public interface IMiddleware
    {
        Task InvokeAsync(HttpContext context, RequestDelegate next, CancellationToken cancellationToken = default);
    }
}
