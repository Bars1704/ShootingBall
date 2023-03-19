using UnityEngine;

namespace Gameplay.FSM
{
    /// <summary>
    /// Player shoots an bullet at this state
    /// </summary>
    public class ShootPlayerState : PlayerStateBase
    {
        private readonly float _bulletSize;

        private readonly GameObject _bulletPrefab;

        public ShootPlayerState(float bulletSize)
        {
            _bulletSize = bulletSize;
        }

        public override void Start()
        {
            var obj = _playerContext.BulletsPool.GetObject();
            obj.Init(_bulletSize, _playerContext.Player.transform.position, SwitchToRunState);
        }

        private void SwitchToRunState(Vector3 position)
        {
            _playerContext.TransitionTo(new RunPlayerState(position, _playerContext.Player.Transform));
        }

        public override void OnDestroy()
        {
        }
    }
}