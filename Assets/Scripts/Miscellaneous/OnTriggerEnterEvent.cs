using System;
using UnityEngine;

namespace Miscellaneous
{
    public class OnTriggerEnterEvent : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEntered;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEntered?.Invoke(other);
        }
    }
}