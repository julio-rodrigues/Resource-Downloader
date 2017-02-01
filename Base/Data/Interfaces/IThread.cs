using System;

namespace Base.Data.Interfaces
{
    public interface IThread
    {
        bool Loop { get; }

        void Run();
        void End();
    }
}

