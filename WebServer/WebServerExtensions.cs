using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public static class WebServerExtensions
    {
        public static byte[] GetBytes(this NetworkStream stream)
        {
            var bytes = new byte[2048];
            int ok = stream.Read(bytes, 0, bytes.Length);
            //TODO: check if ok variable equals 0
            return bytes;
        }
    }
}
