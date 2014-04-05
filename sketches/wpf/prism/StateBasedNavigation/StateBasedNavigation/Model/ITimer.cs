using System;

namespace StateBasedNavigation.Model
{
    public interface ITimer
    {
        event EventHandler Tick;

        void Start();
        void Stop();
    }
}