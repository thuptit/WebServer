using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions
{
    public interface IProtocolHandler
    {
        Task Handle(byte[] buffer);
        Task ProcessPipeline(RequestDelegate middleware);
    }
}
