using UnityEngine;

namespace VFX
{
    [CreateAssetMenu(menuName = "ShootingBall/VFXConfig")]
    public class VFXConfig : ScriptableObject
    {
        public float ExplosionAnimationTime;

        [Tooltip("Delay before destroying objects, that was hit by explosion")]
        public float ObstaclesDestroyDelay;

        public ExplosionEffect ExplosionEffectPrefab;
    }
}