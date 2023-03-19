using System;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Means that object can die 
    /// </summary>
    public class Mortal : MonoBehaviour
    {
        public event Action OnDied;

        public void Die()
        {
            OnDied?.Invoke();
        }
    }
}