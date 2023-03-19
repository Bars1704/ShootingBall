using System;
using Sizes;
using UnityEngine;

namespace Explosions
{
    /// <summary>
    /// Explode and triggers all <see cref="IExplodable"/> instances
    /// </summary>
    [RequireComponent(typeof(ObjectSize))]
    public class Exploding : MonoBehaviour
    {
        /// <summary>
        /// Invokes when exploded
        /// </summary>
        public event Action<Vector3> OnExploded;

        [SerializeField] private float _explosionToSizeMultiplier;
        private ObjectSize _size;

        public float ExplosionSize => _explosionToSizeMultiplier * _size.Value;

        private void Start()
        {
            _size = GetComponent<ObjectSize>();
        }

        public void Explode()
        {
            var explosionPos = transform.position;
            var castResult = Physics.SphereCastAll(explosionPos, ExplosionSize, transform.forward, 0);
            foreach (var raycastHit in castResult)
            {
                foreach (var explodable in raycastHit.transform.GetComponentsInChildren<IExplodable>())
                {
                    explodable.OnExploded();
                }
            }

            OnExploded?.Invoke(explosionPos);
        }
    }
}