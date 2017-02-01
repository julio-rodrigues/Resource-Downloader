using System;
using System.Collections.Generic;
using System.IO;

using Base.Data.Interfaces;
using Base.Data.Abstracts;
using Base.Data.DispatcherBases;

namespace Base.Factories
{
    public class ConfigurationFactory : ADispatcher<IConfigurationDispatcher>, IUpdater, ISingleton
    {
        Dictionary<Type, IConfiguration> Configurations;
        object syncLock;

        public int Interval { get; private set; } = 10000;

        public void Create()
        {
            Configurations = new Dictionary<Type, IConfiguration>();
            syncLock = new object();

            UpdaterFactory.Start(this);
        }

        public void Destroy()
        {
            UpdaterFactory.Stop(this);
        }

        public void Loop()
        {
            End();
        }

        public void End()
        {
            lock (syncLock)
            {
                foreach (var Configuration in Configurations.Values)
                {
                    Dispatch(d => d.Save(Configuration));
                }
            }
        }

        public static bool RegisterConfiguration<TConfiguration>()
            where TConfiguration : IConfiguration
        {
            return RegisterConfiguration(typeof(TConfiguration));
        }

        public static bool RegisterConfiguration(Type ConfigurationType)
        {
            if (typeof(IConfiguration).IsAssignableFrom(ConfigurationType))
            {
                var Factory = SingletonFactory.GetInstance<ConfigurationFactory>();
                return false;
            }
            throw new Exception($"Class {ConfigurationType} don't implements IConfiguration");
        }
    }
}