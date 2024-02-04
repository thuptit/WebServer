using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions.Contexts;

namespace WebServer.Abstractions
{
    public interface IProtocolHandler
    {
        Task<HttpContext> StartProcessAsync(byte[] buffer);
        Task<HttpContext> ProcessPipelineAsync(RequestDelegate middleware);
    }
}
