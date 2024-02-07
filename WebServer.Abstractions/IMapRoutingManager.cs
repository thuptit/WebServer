using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions
{
    public interface IMapRoutingManager
    {
        Type GetControllerByRouteName(string routeName);
        void Intialize(Assembly assembly); 
    }
}
