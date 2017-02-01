using System;
using Base.Data.Interfaces;

namespace Base.Data.DispatcherBases
{
    public interface IThreadDispatcher : IDispatcherBase
    {
        void Start(IThread Thread);
        void Stop(IThread Thread);

        void Run(IThread Thread);
        void End(IThread Thread);
    }
}

