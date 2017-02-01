using System;
using Base.Data.Interfaces;
using System.Threading;

namespace Base.Factories.Tasks
{
    public class UpdaterTask : IThread
    {
        IUpdater Updater;

        public bool Loop { get { return true; } }
        public bool Running { get { return ThreadFactory.IsRunning(this); } }

        public UpdaterTask(IUpdater Updater)
        {
            this.Updater = Updater;
        }

        public void Start()
        {
            ThreadFactory.Start(this);
        }

        public void Stop()
        {
            ThreadFactory.Stop(this);
        }

        public void Run()
        {
            Updater.Loop();
            Thread.Sleep(Updater.Interval);
        }

        public void End()
        {
            Updater.End();
        }
    }
}

