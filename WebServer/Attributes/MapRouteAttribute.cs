using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public sealed class MapRouteAttribute : Attribute
    {
        public readonly string RouteName;
        public MapRouteAttribute(string routeName) => RouteName = routeName;
    }
}
