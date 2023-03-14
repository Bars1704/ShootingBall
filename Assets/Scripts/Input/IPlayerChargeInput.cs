using System;

namespace Input
{
    public interface IPlayerChargeInput
    {
        /// <summary>
        /// Invokes on charge beginning
        /// </summary>
        event Action OnPlayerChargeBegin;

        /// <summary>
        /// Invokes every frame while user is charging. Parameter - time before last invoke
        /// </summary>
        event Action<float> OnPlayerChargeProcess;

        /// <summary>
        /// Invokes on charge ending
        /// </summary>
        event Action OnPlayerChargeEnd;
    }
}