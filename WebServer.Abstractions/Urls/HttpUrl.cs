using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions.Urls
{
    public class HttpUrl
    {
        public string Host { get; private set; }
        public string Path { get; }
        /// <summary>
        /// if port is null -> default is port 80
        /// </summary>
        public int Port { get; }
        public string AbsolutePath { get; }
        /// <summary>
        /// this property form is only used by the CONNECT method
        /// </summary>
        public string Authority { get; set; }
    }
}
