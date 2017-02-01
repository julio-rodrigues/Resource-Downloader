using System;

namespace Base.Data.Interfaces
{
    public interface IDispatcherBase
    {
        void OnDispatch(Action Method);
    }
}

