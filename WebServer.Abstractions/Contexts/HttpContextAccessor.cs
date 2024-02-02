using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions.Contexts
{
    public class HttpContextAccessor : IHttpContextAccessor
    {
        private readonly AsyncLocal<HttpContextHolder> _httpContextCurrent = new AsyncLocal<HttpContextHolder>();
        public HttpContext HttpContext { 
            get 
            {
                return this._httpContextCurrent?.Value.Context;
            }
            set
            {
                var holder = this._httpContextCurrent.Value;
                if (holder != null)
                {
                    holder.Context = null;
                }
                if (value != null)
                {
                    _httpContextCurrent.Value = new HttpContextHolder() { Context = value };
                }
            }
        }

        private sealed class HttpContextHolder
        {
            public HttpContext? Context;
        }
    }
}
