using System;
using System.Threading;
using System.Threading.Tasks;
using Base.Data.Interfaces;
using System.Diagnostics;

namespace Base.Factories.Tasks
{
    public class ThreadTask
    {
        Task RealThread;
        CancellationToken Token;
        CancellationTokenSource Source;

        IThread Instance;

        public bool Running { get; private set; } = false;

        public ThreadTask(IThread Instance)
        {
            this.Instance = Instance;

            Source = new CancellationTokenSource();
            Token = Source.Token;

            RealThread = new Task(Run, Token, TaskCreationOptions.LongRunning);
        }

        public void Start()
        {
            try
            {
                RealThread.Start();
                Running = true;

                var Factory = SingletonFactory.GetInstance<ThreadFactory>();
                Factory.Dispatch(d => d.Start(Instance));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Running = false;
            }
        }

        public void Stop()
        {
            Source.Cancel();
            Running = false;

            var Factory = SingletonFactory.GetInstance<ThreadFactory>();
            Factory.Dispatch(d => d.Stop(Instance));
        }

        void Run()
        {
            try
            {
                do
                {
                    Token.ThrowIfCancellationRequested();
                    Instance.Run();

                    var Factory = SingletonFactory.GetInstance<ThreadFactory>();
                    Factory.Dispatch(d => d.Run(Instance));
                }
                while (Instance.Loop || Running);
            }
            catch (TaskCanceledException) { }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                LoggerFactory.GetLogger().LogFatal(ex);
            }
            finally
            {
                Instance.End();
                var Factory = SingletonFactory.GetInstance<ThreadFactory>();
                Factory.Dispatch(d => d.End(Instance));
            }
        }
    }
}