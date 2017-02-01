using System;
using Base.Data.Interfaces;
using System.Collections.Generic;

namespace Base.Factories
{
    public class QueueFactory : ISingleton
    {
        Dictionary<int, Queue<object>> Queues;
        object syncLock;

        public void Create()
        {
            Queues = new Dictionary<int, Queue<object>>();
            syncLock = new object();
        }

        public void Destroy()
        {
            lock (syncLock)
            {
                Queues.Clear();
                Queues = null;

                GC.WaitForPendingFinalizers();
            }
        }

        public static void Enqueue<TQueue>(object Value)
            where TQueue : IQueue
        {
            Enqueue(typeof(TQueue), Value);
        }

        public static void Enqueue(Type QueueType, object Value)
        {
            if (typeof(IQueue).IsAssignableFrom(QueueType))
            {
                Enqueue(QueueType.GetHashCode(), Value);
            }
            else
                throw new Exception($"The class {QueueType} don't implement IQueue!");
        }

        public static void Enqueue(IQueue Queue, object Value)
        {
            Enqueue(Queue.GetHashCode(), Value);
        }

        static void Enqueue(int ID, object Value)
        {
            var Factory = SingletonFactory.GetInstance<QueueFactory>();

            if (!Factory.Queues.ContainsKey(ID))
                lock (Factory.syncLock)
                    Factory.Queues.Add(ID, new Queue<object>());

            lock (Factory.Queues[ID])
                Factory.Queues[ID].Enqueue(Value);
        }

        public static object Dequeue<TQueue>()
            where TQueue : IQueue
        {
            return Dequeue(typeof(TQueue));
        }

        public static object Dequeue(Type QueueType)
        {
            if (typeof(IQueue).IsAssignableFrom(QueueType))
            {
                return Dequeue(QueueType.GetHashCode());
            }
            throw new Exception($"The class {QueueType} don't implement IQueue!");
        }

        public static object Dequeue(IQueue Queue)
        {
            return Dequeue(Queue.GetHashCode());
        }

        static object Dequeue(int ID)
        {
            var Factory = SingletonFactory.GetInstance<QueueFactory>();
            if(Factory.Queues.ContainsKey(ID) && Factory.Queues[ID].Count > 0)
            {
                lock (Factory.Queues[ID])
                    return Factory.Queues[ID].Dequeue();
            }
            return null;
        }

        public static TValue Dequeue<TQueue, TValue>()
            where TQueue : IQueue
        {
            object Value = Dequeue<TQueue>();
            return Value == null || !(Value is TValue)
                ? default(TValue) : (TValue)Value;
        }

        public static TValue Dequeue<TValue>(IQueue Queue)
        {
            object Value = Dequeue(Queue);
            return Value == null || !(Value is TValue)
                ? default(TValue) : (TValue)Value;
        }

        public static void Clear(Type QueueType)
        {
            if (typeof(IQueue).IsAssignableFrom(QueueType))
            {
                Clear(QueueType.GetHashCode());
            }
            throw new Exception($"The class {QueueType} don't implement IQueue!");
        }

        public static void Clear<TQueue>()
            where TQueue: IQueue
        {
            Clear(typeof(TQueue));
        }

        public static void Clear(IQueue Queue)
        {
            Clear(Queue.GetHashCode());
        }

        static void Clear(int ID)
        {
            var Factory = SingletonFactory.GetInstance<QueueFactory>();
            if (Factory.Queues.ContainsKey(ID))
            {
                lock (Factory.Queues[ID])
                    Factory.Queues[ID].Clear();
            }
        }
    }
}