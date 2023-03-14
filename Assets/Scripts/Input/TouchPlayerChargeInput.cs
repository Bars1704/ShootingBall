using System;
using UnityEngine;

namespace Input
{
    public class TouchPlayerChargeInput : MonoBehaviour, IPlayerChargeInput
    {
        public event Action OnPlayerChargeBegin;
        public event Action<float> OnPlayerChargeProcess;
        public event Action OnPlayerChargeEnd;

        private bool _isChargingAtLastFrame;

        private void Update()
        {
            var isTouching = UnityEngine.Input.touchCount > 0;

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