using System;
using System.Collections.Generic;

using Base.Data.Interfaces;


namespace Base.Factories
{
    public static class SingletonFactory
    {
        static Dictionary<Type, ISingleton> Singletons = new Dictionary<Type, ISingleton>();
        static object syncLock = new object();

        public static ISingleton GetInstance(Type SingletonType)
        {
            if (typeof(ISingleton).IsAssignableFrom(SingletonType))
            {
                lock (syncLock)
                {
                    if (!Singletons.ContainsKey(SingletonType))
                    {
                        var Singleton = (ISingleton)Activator.CreateInstance(SingletonType);
                        Singleton.Create();

                        Singletons.Add(SingletonType, Singleton);
                    }
                    return Singletons[SingletonType];
                }
            }
            else
                throw new Exception($"The class {SingletonType} don't ISingleton interface!");
        }

        public static TSingleton GetInstance<TSingleton>()
            where TSingleton : ISingleton
        {
            return (TSingleton)GetInstance(typeof(TSingleton));
        }
    }
}

