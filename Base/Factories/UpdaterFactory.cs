using System;
using Base.Data.Interfaces;
using System.Collections.Generic;
using Base.Factories.Tasks;
using System.Linq;

namespace Base.Factories
{
    public class UpdaterFactory : ISingleton
    {
        Dictionary<int, UpdaterTask> Tasks;

        object syncLock;

        public void Create()
        {
            Tasks = new Dictionary<int, UpdaterTask>();
            syncLock = new object();
        }

        public void Destroy()
        {
            lock (syncLock)
            {
                foreach (UpdaterTask Task in Tasks.Values)
                    Task.Stop();
            }
            GC.WaitForPendingFinalizers();
        }

        public static void Start<TUpdater>()
            where TUpdater : IUpdater
        {
            Start(typeof(TUpdater));
        }

        public static void Start(Type UpdaterType)
        {
            if (typeof(IUpdater).IsAssignableFrom(UpdaterType))
            {
                var Factory = SingletonFactory.GetInstance<UpdaterFactory>();
                var ID = UpdaterType.GetHashCode();

               

                Start(ID);
            }
            else
                throw new Exception($"Class {UpdaterType} don't implements IUpdater");
        }

        public static void Start(IUpdater Updater)
        {
            var Factory = SingletonFactory.GetInstance<UpdaterFactory>();
            var ID = Updater.GetHashCode();

            if (!Factory.Tasks.ContainsKey(ID))
            {
                lock (Factory.syncLock)
                    Factory.Tasks.Add(ID, new UpdaterTask(Updater));
            }

            Start(ID);
        }

        static void Start(int ID)
        {
            var Factory = SingletonFactory.GetInstance<UpdaterFactory>();
            var Task = Factory.Tasks[ID];

            if (!Task.Running)
                Task.Start();
            else
                throw new Exception("Updater as already started!");
        }

        public static void Stop<TUpdater>()
            where TUpdater : IUpdater
        {
            Stop(typeof(TUpdater));
        }

        public static void Stop(Type UpdaterType)
        {
            if (typeof(IUpdater).IsAssignableFrom(UpdaterType))
            {
                Stop(UpdaterType.GetHashCode());
            }
            else
                throw new Exception($"Class {UpdaterType} don't implements IUpdater");
        }

        public static void Stop(IUpdater Updater)
        {
            Stop(Updater.GetHashCode());
        }

        static void Stop(int ID)
        {
            var Factory = SingletonFactory.GetInstance<UpdaterFactory>();

            if (Factory.Tasks.ContainsKey(ID))
            {
                var Task = Factory.Tasks[ID];

                if (Task.Running)
                    Task.Stop();
                else
                    throw new Exception("Updater as not been started!");
            }
            else
                throw new Exception("Updater as not been created!");
        }
    }
}