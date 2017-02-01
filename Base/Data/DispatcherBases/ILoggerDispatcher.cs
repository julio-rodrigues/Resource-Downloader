using System;
using Base.Data.Interfaces;
using Base.Data.Enums;

namespace Base.Data.DispatcherBases
{
    public interface ILoggerDispatcher : IDispatcherBase
    {
        void OnLog(ILogger Logger, LogType Type, string Message);
    }
}

