using UnityEngine;

namespace Player.Configs
{
    [CreateAssetMenu(menuName = "ShootingBall/LevelSettings")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _bulletSizeMultiplier;
        [SerializeField] private float _playerSize;
        [SerializeField] private PlayerMovingConfig _playerMovingConfig;
        public float PlayerSize => _playerSize;
        public PlayerMovingConfig PlayerMovingConfig => _playerMovingConfig;
        public float BulletSizeMultiplier => _bulletSizeMultiplier;
    }
}