using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions;

namespace WebServer.Middlewares
{
    public class MapRoutingManager : IMapRoutingManager
    {
        private readonly ConcurrentDictionary<string, Type> _controllerTypes = new();
        public Type GetControllerByRouteName(string routeName)
        {
            throw new NotImplementedException();
        }

        public void Intialize(Assembly assembly)
        {
            throw new NotImplementedException();
        }
    }
}
