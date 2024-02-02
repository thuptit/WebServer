using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions.Contexts
{
    public interface IHttpContextAccessor
    {
        public HttpContext HttpContext { get; set; }
    }
}
