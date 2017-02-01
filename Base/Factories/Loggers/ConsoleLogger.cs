using System;
using Base.Data.Interfaces;
using Base.Data.Enums;
using System.Diagnostics;

namespace Base.Factories.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public string Name { get; private set; }

        public ConsoleLogger(string Name)
        {
            this.Name = Name;
        }

        public void LogInfo(string Message, params object[] Arguments)
        {
            Enqueue(() => WriteMessage(LogType.Information, Message, Arguments));
        }

        public void LogDebug(string Message, params object[] Arguments)
        {
            Enqueue(() =>
            {
                if (Debugger.IsAttached)
                    Debug.WriteLine(string.Format(Message, Arguments));

                WriteMessage(LogType.Debug, Message, Arguments);
            });
        }

        public void LogSuccess(string Message, params object[] Arguments)
        {
            Enqueue(() => WriteMessage(LogType.Success, Message, Arguments));
        }

        public void LogWarning(string Message, params object[] Arguments)
        {
            Enqueue(() => WriteMessage(LogType.Warning, Message, Arguments));
        }

        public void LogError(string Message, params object[] Arguments)
        {
            Enqueue(() => WriteMessage(LogType.Error, Message, Arguments));
        }

        public void LogFatal(Exception Error)
        {
            string Message = $"{Error.GetType()}: {Error.Message}";
#if DEBUG
            Message += Environment.NewLine + Error.StackTrace;
#endif

            Enqueue(() => WriteMessage(LogType.Fatal, Message));
        }

        void Enqueue(Action LogAction)
        {
            QueueFactory.Enqueue<LoggerFactory>(LogAction);
        }

        void WriteMessage(LogType Type, string Message, params object[] Args)
        {
            Message = string.Format(Message, Args);

            var Factory = SingletonFactory.GetInstance<LoggerFactory>();
            Factory.Dispatch(d => d.OnLog(this, Type, Message));

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{DateTime.Now} - ");

            switch (Type)
            {
                case LogType.Information:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogType.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case LogType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogType.Fatal:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
            }
            Console.Write($"{Type}|{Name}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"]: {Message}");
            Console.ResetColor();
        }
    }
}

