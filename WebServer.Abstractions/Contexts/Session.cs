using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions.Contexts
{
    public class Session : ISession
    {
        public ConcurrentDictionary<string, object> Sessions => new ();

        public void Add(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {

        }
    }
}
