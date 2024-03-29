﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Abstractions
{
    public interface IServer : IDisposable
    {
        Task Start();
        Task Stop(CancellationToken cancellationToken = default);
    }
}
