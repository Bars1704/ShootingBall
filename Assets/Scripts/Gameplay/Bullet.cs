using System;
using Explosions;
using Reflex.Scripts.Attributes;
using Sizes;
using UnityEngine;
using VFX;

namespace Gameplay
{
    [RequireComponent(typeof(ObjectSize), typeof(Exploding))]
    public class Bullet : MonoBehaviour
    {
        private ObjectSize _size;
        private Transform _transform;
        private Exploding _explodeOnCollision;
        private Action<Vector3> _onBulletExplode;
        private VFXConfig _config;
        private bool _isCached;

        private ExplosionEffect _explosionEffect;

        [Inject]
        private void Inject(VFXConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Cache components
        /// </summary>
        private void CacheComponents()
        {
            if (_isCached) return;

            _transform = transform;
            _size = GetComponent<ObjectSize>();
            _explodeOnCollision = GetComponent<Exploding>();
            _isCached = true;
        }

        private void OnDestroy()
        {
            if (_explodeOnCollision != default)
                _explodeOnCollision.OnExploded -= OnExploded;
        }

        /// <summary>
        /// Inits bullet before launch
        /// </summary>
        /// <param name="size">Bullet  size</param>
        /// <param name="position">Bullet position</param>
        /// <param name="onBulletExplode">Invokes when bullet explodes</param>
        public void Init(float size, Vector3 position, Action<Vector3> onBulletExplode)
        {
            CacheComponents();

            _onBulletExplode = onBulletExplode;
            _size.Value = size;
            _transform.position = position;

            _explodeOnCollision.OnExploded += OnExploded;
        }

        private void OnExploded(Vector3 position)
        {
            ShowExplodeEffect();
            _onBulletExplode?.Invoke(position);
        }

        private void ShowExplodeEffect()
        {
            if (_explosionEffect == default)
                _explosionEffect = Instantiate(_config.ExplosionEffectPrefab);

            _explosionEffect.transform.position = transform.position;
            _explosionEffect.Explode(_explodeOnCollision.ExplosionSize, _config.ExplosionAnimationTime);
        }
    }
}