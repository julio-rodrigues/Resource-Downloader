using System;
using Base.Data.Interfaces;

namespace Base.Factories.Loggers
{
    public class EventLogger : ILogger
    {
        public string Name { get; private set; }

        public EventLogger(string Name)
        {
            this.Name = Name;
        }

        public void LogInfo(string Message, params object[] Arguments)
        {
            throw new NotImplementedException();
        }

        public void LogDebug(string Message, params object[] Arguments)
        {
            throw new NotImplementedException();
        }

        public void LogTrace(string Message, params object[] Arguments)
        {
            throw new NotImplementedException();
        }

        public void LogSuccess(string Message, params object[] Arguments)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string Message, params object[] Arguments)
        {
            throw new NotImplementedException();
        }

        public void LogError(string Message, params object[] Arguments)
        {
            throw new NotImplementedException();
        }

        public void LogFatal(Exception Error)
        {
            throw new NotImplementedException();
        }
    }
}

