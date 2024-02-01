using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions.Contexts;
using WebServer.Abstractions.Contexts.Requests;
using WebServer.Abstractions.HttpProtocols;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebServer.Abstractions.Parsers
{
    public class HttpRequestParser : IHttpComponentParser
    {
        private static readonly byte[] HTTP1_1_Bytes = Encoding.ASCII.GetBytes("HTTP/1.1");
        private static readonly byte[] HTTP1_1_CR_Bytes = Encoding.ASCII.GetBytes("HTTP/1.1\r");
        private int _maxUrlPartLength;
        public HttpRequestParser(int maxUrlPartLength = -1) =>  _maxUrlPartLength = maxUrlPartLength == -1 ? maxUrlPartLength = 8192 : maxUrlPartLength;

        private static readonly Dictionary<HttpMethod, byte[]> supportedMethodBytes = new() {
            {
                HttpMethod.Get,
                Encoding.ASCII.GetBytes(HttpMethods.GET.ToString())
            },
            {
                HttpMethod.Post,
                Encoding.ASCII.GetBytes(HttpMethods.POST.ToString())
            },
            {
                HttpMethod.Put,
                Encoding.ASCII.GetBytes(HttpMethods.PUT.ToString())
            },
            {
                HttpMethod.Delete,
                Encoding.ASCII.GetBytes(HttpMethods.DELETE.ToString())
            },
            {
                HttpMethod.Connect,
                Encoding.ASCII.GetBytes(HttpMethods.CONNECT.ToString())
            },
            {
                HttpMethod.Options,
                Encoding.ASCII.GetBytes(HttpMethods.OPTIONS.ToString())
            },
            {
                HttpMethod.Trace,
                Encoding.ASCII.GetBytes(HttpMethods.TRACE.ToString())
            }
        };
        public HttpRequestHeader ParserHttpRequestHeader(ReadOnlySequence<byte> bytes)
        {
            throw new NotImplementedException();
        }

        public HttpRequestLine ParserHttpRequestLine(ReadOnlySequence<byte> bytes)
        {
            throw new NotImplementedException();
        }
    }
}
