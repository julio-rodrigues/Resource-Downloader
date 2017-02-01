using System;
using Base.Data.Interfaces;
using System.Collections.Generic;

namespace Base.Factories
{
    public class StackFactory : ISingleton
    {
        Dictionary<int, Stack<object>> Stacks;
        object syncLock;

        public void Create()
        {
            Stacks = new Dictionary<int, Stack<object>>();
            syncLock = new object();
        }

        public void Destroy()
        {
            lock (syncLock)
            {
                Stacks.Clear();
                Stacks = null;

                GC.WaitForPendingFinalizers();
            }
        }

        public static void Push<TStack>(object Value)
            where TStack : IStack
        {
            Push(typeof(TStack), Value);
        }

        public static void Push(Type StackType, object Value)
        {
            if (typeof(IStack).IsAssignableFrom(StackType))
            {
                Push(StackType.GetHashCode(), Value);
            }
            else
                throw new Exception($"The class {StackType} don't implement IStack!");
        }

        public static void Push(IStack Stack, object Value)
        {
            Push(Stack.GetHashCode(), Value);
        }

        static void Push(int ID, object Value)
        {
            var Factory = SingletonFactory.GetInstance<StackFactory>();

            if (!Factory.Stacks.ContainsKey(ID))
                lock (Factory.syncLock)
                    Factory.Stacks.Add(ID, new Stack<object>());

            lock (Factory.Stacks[ID])
                Factory.Stacks[ID].Push(Value);
        }

        public static object Pop<TStack>()
            where TStack : IStack
        {
            return Pop(typeof(TStack));
        }

        public static object Pop(Type StackType)
        {
            if (typeof(IStack).IsAssignableFrom(StackType))
            {
                return Pop(StackType.GetHashCode());
            }
            throw new Exception($"The class {StackType} don't implement IStack!");
        }

        public static object Pop(IStack Stack)
        {
            return Pop(Stack.GetHashCode());
        }

        static object Pop(int ID)
        {
            var Factory = SingletonFactory.GetInstance<StackFactory>();
            if (Factory.Stacks.ContainsKey(ID))
            {
                lock (Factory.Stacks[ID])
                    return Factory.Stacks[ID].Pop();
            }
            return null;
        }

        public static TValue Pop<TStack, TValue>()
            where TStack : IStack
        {
            object Value = Pop<TStack>();
            return Value == null || !(Value is TValue)
                ? default(TValue) : (TValue)Value;
        }

        public static TValue Pop<TValue>(IStack Stack)
        {
            object Value = Pop(Stack);
            return Value == null || !(Value is TValue)
                ? default(TValue) : (TValue)Value;
        }

        public static void Clear(Type StackType)
        {
            if (typeof(IStack).IsAssignableFrom(StackType))
            {
                Clear(StackType.GetHashCode());
            }
            throw new Exception($"The class {StackType} don't implement IStack!");
        }

        public static void Clear<TStack>()
            where TStack : IStack
        {
            Clear(typeof(TStack));
        }

        public static void Clear(IStack Stack)
        {
            Clear(Stack.GetHashCode());
        }

        static void Clear(int ID)
        {
            var Factory = SingletonFactory.GetInstance<StackFactory>();
            if (Factory.Stacks.ContainsKey(ID))
            {
                lock (Factory.Stacks[ID])
                    Factory.Stacks[ID].Clear();
            }
        }
    }
}