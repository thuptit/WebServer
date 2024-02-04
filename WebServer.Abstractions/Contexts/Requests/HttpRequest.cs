using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions.Urls;

namespace WebServer.Abstractions.Contexts.Requests
{
    public sealed class HttpRequest
    {
        public HttpRequest(string httpMethod, HttpHeader header, object? body, HttpUrl httpUrl)
        {
            HttpMethod = httpMethod;
            Headers = header;
            Body = body;
            HttpUrl = httpUrl;
        }
        public HttpUrl HttpUrl { get; init; }
        public string HttpMethod { get; init; }
        public HttpHeader Headers { get; init; }
        public object? Body { get; init; }
    }
}
