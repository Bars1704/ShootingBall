using System;
using UnityEngine;

namespace Input
{
    /// <summary>
    /// Player charge input, based on one action (mouse \ keyboard button press, screen touch, etc)
    /// </summary>
    public abstract class SingleActionPlayerChargeInput : MonoBehaviour, IPlayerChargeInput
    {
        public event Action OnPlayerChargeBegin;
        public event Action<float> OnPlayerChargeProcess;
        public event Action OnPlayerChargeEnd;

        private bool _isChargingAtLastFrame;

        protected abstract bool IsInputActivated();

        private void Update()
        {
            var isTouching = IsInputActivated();

            if (isTouching)
            {
                if (_isChargingAtLastFrame)
                    OnPlayerChargeProcess?.Invoke(Time.deltaTime);
                else
                    OnPlayerChargeBegin?.Invoke();
            }
            else if (_isChargingAtLastFrame)
            {
                OnPlayerChargeEnd?.Invoke();
            }

            _isChargingAtLastFrame = isTouching;
        }
    }
}