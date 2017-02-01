using System;

namespace Base.Data.Interfaces
{
    public interface ILogger
    {
        string Name { get; }
        void LogInfo(string Message, params object[] Arguments);
        void LogWarning(string Message, params object[] Arguments);
        void LogSuccess(string Message, params object[] Arguments);
        void LogDebug(string Message, params object[] Arguments);
        void LogError(string Message, params object[] Arguments);
        void LogFatal(Exception Error);
    }
}

