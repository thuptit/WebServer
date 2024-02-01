using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions.HttpProtocols
{
    public enum HttpMethods : byte
    {
        OPTIONS,
        GET,
        POST,
        PUT,
        DELETE,
        TRACE,
        CONNECT
    }
}
