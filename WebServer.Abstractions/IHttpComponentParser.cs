using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions.Contexts.Requests;

namespace WebServer.Abstractions
{
    public interface IHttpComponentParser
    {
        HttpRequest ParserHttpRequest(string content);
    }
}
