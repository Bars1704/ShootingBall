using System;

namespace Timers
{
    public interface ITimer
    {
        void DoWithDelay(float delay, Action action);
    }
}