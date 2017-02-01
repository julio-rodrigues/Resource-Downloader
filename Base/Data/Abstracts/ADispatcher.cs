using System;
using Base.Data.Interfaces;
using System.Collections.Generic;

namespace Base.Data.Abstracts
{
    public abstract class ADispatcher<TDispatcherBase>
        where TDispatcherBase : IDispatcherBase
    {
        List<TDispatcherBase> Dispatchers = new List<TDispatcherBase>();
        readonly object syncLock = new object();

        public int Count { get { return Dispatchers.Count; } }

        public void RegisterDispatcher<TDispatcher>()
            where TDispatcher : TDispatcherBase
        {
            var Dispatcher = Activator.CreateInstance<TDispatcher>();
            RegisterDispatcher(Dispatcher);
        }

        public void RegisterDispatcher(TDispatcherBase Dispatcher)
        {
            lock (syncLock)
            {
                if (!Dispatchers.Contains(Dispatcher))
                    Dispatchers.Add(Dispatcher);
            }
        }

        public void Dispatch(Action<TDispatcherBase> Method)
        {
            lock (syncLock)
            {
                foreach (var Dispatcher in Dispatchers)
                    Dispatcher.OnDispatch(() => Method(Dispatcher));
            }
        }
    }
}