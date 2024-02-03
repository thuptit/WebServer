using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions
{
    public interface IApplicationBuilder
    {
        IServiceProvider ApplicationServices { get; }
        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);
    }
}
