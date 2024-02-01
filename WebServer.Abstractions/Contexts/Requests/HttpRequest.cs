using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions.Contexts.Requests
{
    public class HttpRequest
    {
        public HttpRequest() { }
        public string HttpMethod { get; private set; }
        public HttpRequestHeader Headers { get; set; }
        public HttpRequestBody Body { get; set; }
    }
}
