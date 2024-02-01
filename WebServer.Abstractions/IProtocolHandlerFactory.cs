using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions.HttpProtocols;

namespace WebServer.Abstractions
{
    public interface IProtocolHandlerFactory
    {
        IProtocolHandler Create(string version);
    }
}
