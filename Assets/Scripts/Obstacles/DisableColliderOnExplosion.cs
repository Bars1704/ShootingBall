using System;
using Explosions;
using Gameplay;
using Restorables;
using UnityEngine;

namespace Obstacles
{
    public class DisableColliderOnExplosion : MonoBehaviour, IExplodable, IRestorable
    {
        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        public void OnExploded()
        {
            _collider.enabled = false;
        }

        public void Restore()
        {
            _collider.enabled = true;
        }
    }
}