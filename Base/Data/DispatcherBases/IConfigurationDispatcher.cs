using System;
using Base.Data.Interfaces;

namespace Base.Data.DispatcherBases
{
    public interface IConfigurationDispatcher : IDispatcherBase
    {
        void Load(IConfiguration Configuration);
        void Save(IConfiguration Configuration);
    }
}

