using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions.Contexts;

namespace WebServer.Abstractions
{
    public delegate Task RequestDelegate(HttpContext context);
}
