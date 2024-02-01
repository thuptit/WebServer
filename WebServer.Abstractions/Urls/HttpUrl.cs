using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions.Urls
{
    public class HttpUrl
    {
        public HttpUrl(string uri) => ExtractUri(uri);

        private void ExtractUri(string Uri)
        {
            //TODO: extract HTTP Url from URI in header 
        }
        public string Host { get; private set; }
        public string Path { get; private set; }
        /// <summary>
        /// if port is null -> default is port 80
        /// </summary>
        public int Port { get; private set; }
        public string AbsolutePath { get; private set; }
        /// <summary>
        /// this property form is only used by the CONNECT method
        /// </summary>
        public string Authority { get; private set; }
    }
}
