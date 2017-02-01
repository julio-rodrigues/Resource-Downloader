using System;
using Base.Data.Interfaces;
using Base.Data.DispatcherBases;
using Base.Data.Abstracts;
using System.Collections.Generic;
using Base.Factories.Loggers;

using System.Runtime.CompilerServices;
using System.IO;

namespace Base.Factories
{
    public class LoggerFactory :
    ADispatcher<ILoggerDispatcher>, ISingleton, IUpdater, IQueue
    {
        Dictionary<string, ILogger> Loggers;

        public int Interval { get; private set; }
        public static Type LoggerType { get; set; } = typeof(ConsoleLogger);

        public void Create()
        {
            Loggers = new Dictionary<string, ILogger>();
            UpdaterFactory.Start(this);
        }

        public void Destroy()
        {
            UpdaterFactory.Stop(this);
        }

        public void Loop()
        {
           
            Action LogAction = QueueFactory.Dequeue<LoggerFactory, Action>();

            if (LogAction != null)
            {
                LogAction();
            }
        }

        public void End()
        {
            Action LogAction = null;

            while ((LogAction = QueueFactory.Dequeue<LoggerFactory, Action>())
                   != null)
            {
                LogAction();
            }
        }

        public static ILogger GetLogger<Type>()
        {
            return GetLogger(typeof(Type));
        }

        public static ILogger GetLogger(object Value)
        {
            return GetLogger((Value ?? "NULL").ToString());
        }

        public static ILogger GetLogger([CallerFilePathAttribute]string Name = "")
        {
            Name = Path.GetFileNameWithoutExtension(Name);

            var Factory = SingletonFactory.GetInstance<LoggerFactory>();
            if (!Factory.Loggers.ContainsKey(Name))
            {
                var Logger = (ILogger)Activator.CreateInstance(LoggerType, Name);
                Factory.Loggers.Add(Name, Logger);
            }
            return Factory.Loggers[Name];
        }
    }
}