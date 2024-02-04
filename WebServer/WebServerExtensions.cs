using System;
using System.Collections.Generic;
using System.Linq;
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
            int ok = stream.Read(bytes, 0, bytes.Length);
            //TODO: check if ok variable equals 0
            return bytes;
        }
        public static void UseMiddleware<T>(this IApplicationBuilder app)
        {

        }
    }
}
