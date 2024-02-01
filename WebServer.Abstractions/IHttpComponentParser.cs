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
        HttpRequestHeader ParserHttpRequestHeader(ReadOnlySequence<byte> bytes);
        HttpRequestLine ParserHttpRequestLine(ReadOnlySequence<byte> bytes);
    }
}
