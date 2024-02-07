using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions;

namespace WebServer
{
    public static class WebServerExtensions
    {
        public static byte[] GetBytes(this NetworkStream stream)
        {
            var bytes = new byte[stream.Socket.Available];
            int numOfBytes = stream.Read(bytes, 0, bytes.Length);
            if (numOfBytes == 0)
                throw new EndOfStreamException("Socket was closed");
            return bytes;
        }
        public static void UseMiddleware<T>(this IApplicationBuilder app) where T : IMiddleware
        {
            app.UseMiddleware(typeof(T));
        }
    }
}
