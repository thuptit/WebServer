﻿using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions;
using WebServer.Abstractions.Contexts;
using WebServer.Abstractions.Contexts.Requests;
using WebServer.Abstractions.HttpProtocols;

namespace WebServer.Handlers
{
    public class DefaultHttp11ProtocolHandler(IServiceProvider serviceProvider, IHttpComponentParser httpComponentParser, IHttpContextAccessor httpContextAccessor) 
        : IProtocolHandler
    {
        public async Task Handle(byte[] buffer)
        {
            var httpRequest = GetHttpRequest(buffer);
            httpContextAccessor.HttpContext = new DefaultHttpContext(httpRequest, serviceProvider);
            // through middleware

            //through controller

            //received httpcontext
        }

        private HttpRequest GetHttpRequest(byte[] bytes)
        {
            var content = Encoding.UTF8.GetString(bytes);
            return httpComponentParser.ParserHttpRequest(content);
        }
    }
}
