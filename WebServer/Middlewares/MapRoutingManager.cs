using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebServer.Abstractions;
using WebServer.Attributes;

namespace WebServer.Middlewares
{
    public class MapRoutingManager : IMapRoutingManager
    {
        private readonly ConcurrentDictionary<string, Type> _controllerTypes = new();
        public Type? GetControllerByRouteName(string routeName)
        {
            return _controllerTypes.GetValueOrDefault(routeName);
        }

        public void Initialize(Assembly assembly)
        {
            var types = assembly.GetTypes();
            var controllerTypes = types.Where(t => t.GetCustomAttribute<ControllerAttribute>() is not null && !t.IsAbstract)
                .ToList();
            foreach (var controllerType in controllerTypes.Where(x => x.GetCustomAttribute<MapRouteAttribute>() is not null))
            {
                var routeName = controllerType.GetCustomAttribute<MapRouteAttribute>()?.RouteName;
                if (routeName != null)
                    _controllerTypes.TryAdd(routeName,
                        controllerType);
                
                //TODO: add logger
            }
        }
    }
}
