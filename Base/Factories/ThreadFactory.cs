using System;
using System.Linq;

using System.Collections.Generic;

using Base.Factories.Tasks;
using Base.Data.Abstracts;
using Base.Data.Interfaces;
using Base.Data.DispatcherBases;

namespace Base.Factories
{
    public class ThreadFactory : ADispatcher<IThreadDispatcher>, ISingleton
    {
        Dictionary<int, ThreadTask> Tasks;

        object syncLock;

        public void Create()
        {
            Tasks = new Dictionary<int, ThreadTask>();
            syncLock = new object();
        }

        public void Destroy()
        {
            lock (syncLock)
            {
                foreach (ThreadTask Task in Tasks.Values)
                    Task.Stop();
            }
            GC.WaitForPendingFinalizers();
        }

        public static void Start<TThread>()
            where TThread : IThread
        {
            Start(typeof(TThread));
        }

        public static void Start(Type ThreadType)
        {
            if (typeof(IThread).IsAssignableFrom(ThreadType))
            {
                var Factory = SingletonFactory.GetInstance<ThreadFactory>();
                var ID = ThreadType.GetHashCode();

                Start(ID);
            }
            else
                throw new Exception($"Class {ThreadType} don't implements IThread");
        }

        public static void Start(IThread Thread)
        {
            var Factory = SingletonFactory.GetInstance<ThreadFactory>();
            var ID = Thread.GetHashCode();

            if (!Factory.Tasks.ContainsKey(ID))
            {
                lock (Factory.syncLock)
                    Factory.Tasks.Add(ID, new ThreadTask(Thread));
            }

            Start(ID);
        }

        static void Start(int ID)
        {
            var Factory = SingletonFactory.GetInstance<ThreadFactory>();
            var Task = Factory.Tasks[ID];

            if (!Task.Running)
                Task.Start();
            else
                throw new Exception("Thread as already started!");
        }

        public static void Stop<TThread>()
            where TThread : IThread
        {
            Stop(typeof(TThread));
        }

        public static void Stop(Type ThreadType)
        {
            if (typeof(IThread).IsAssignableFrom(ThreadType))
            {
                Stop(ThreadType.GetHashCode());
            }
            else
                throw new Exception($"Class {ThreadType} don't implements IThread");
        }

        public static void Stop(IThread Thread)
        {
            Stop(Thread.GetHashCode());
        }

        static void Stop(int ID)
        {
            var Factory = SingletonFactory.GetInstance<ThreadFactory>();

            if (Factory.Tasks.ContainsKey(ID))
            {
                var Task = Factory.Tasks[ID];

                if (Task.Running)
                    Task.Stop();
                else
                    throw new Exception("Thread as not been started!");
            }
            else
                throw new Exception("Thread as not been created!");
        }

        public static void WaitForAll()
        {
            var Factory = SingletonFactory.GetInstance<ThreadFactory>();

            while (Factory.Tasks.Any(kp => kp.Value.Running))
            {
                
            }
        }

        public static bool IsRunning<TThread>()
            where TThread : IThread
        {
            return IsRunning(typeof(TThread));
        }

        public static bool IsRunning(Type ThreadType)
        {
            if (typeof(IThread).IsAssignableFrom(ThreadType))
                return IsRunning(ThreadType.GetHashCode());
            throw new Exception($"The class {ThreadType} don't implements IThread");
        }

        public static bool IsRunning(IThread Thread)
        {
            return IsRunning(Thread.GetHashCode());
        }

        static bool IsRunning(int ID)
        {
            var Factory = SingletonFactory.GetInstance<ThreadFactory>();
            return Factory.Tasks.ContainsKey(ID) && Factory.Tasks[ID].Running;
        }
    }
}