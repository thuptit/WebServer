using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions.Contexts.Requests
{
    public class HttpRequestHeader
    {
        private readonly IDictionary<string, string> _headers;
        public HttpRequestHeader(IDictionary<string, string> nameValueCollections)
        {
            _headers = nameValueCollections;
        }
    }
}
