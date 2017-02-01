using System;

namespace Base.Data.Interfaces
{
    public interface IUpdater
    {
        int Interval { get; }

        void Loop();
        void End();
    }
}

