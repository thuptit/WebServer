using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public class WebApplicationBuilder
    {
        private static WebApplication _webApplication= null!;
        public WebApplicationBuilder() => _webApplication = new();
        public WebApplication Build() => _webApplication;
    }
}
