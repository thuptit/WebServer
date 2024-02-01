using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions
{
    public interface ISession
    {
        ConcurrentDictionary<string, object> Sessions { get; }
        void Remove(string key);
        void Clear();
        void Add(string key, object value);
    }
}
