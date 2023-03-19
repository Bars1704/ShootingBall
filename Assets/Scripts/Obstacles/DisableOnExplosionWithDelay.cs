using Explosions;
using Reflex.Scripts.Attributes;
using Timers;
using UnityEngine;
using VFX;

namespace Obstacles
{
    public class DisableOnExplosionWithDelay : MonoBehaviour, IExplodable
    {
        private VFXConfig _config;
        private ITimer _timer;

        [Inject]
        private void Inject(ITimer timer, VFXConfig config)
        {
            _timer = timer;
            _config = config;
        }

        public void OnExploded()
        {
            _timer.DoWithDelay(_config.ObstaclesDestroyDelay, () => gameObject.SetActive(false));
        }
    }
}