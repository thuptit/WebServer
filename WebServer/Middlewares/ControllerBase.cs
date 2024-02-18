using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Attributes;

namespace WebServer.Middlewares
{
    [Controller]
    public abstract class ControllerBase
    {
        //TODO: define which need to have in controller such as: HttpContext, url, meta-data
        //add attribute convention base in this controller
    }
}
