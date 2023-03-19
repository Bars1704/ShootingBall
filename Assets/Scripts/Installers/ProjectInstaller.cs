using Input;
using Miscellaneous;
using Player;
using Player.Configs;
using Player.FSM;
using Reflex;
using Reflex.Scripts;
using Timers;
using UnityEngine;
using VFX;

namespace Installers
{
    public class ProjectInstaller : Installer
    {
        [SerializeField] private SingleActionPlayerChargeInput _deviceInputPrefab;
        [SerializeField] private SingleActionPlayerChargeInput _testInputPrefab;
        [SerializeField] private CoroutineTimer _timer;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private VFXConfig _vfxConfig;

        public override void InstallBindings(Container container)
        {
            BindInput(container);
            container.BindInstance(new ObjectPool<Bullet>(_bulletPrefab, 1));
            container.BindInstance(_playerConfig);
            container.BindInstance(_vfxConfig);
            container.BindInstanceAs<ITimer>(_timer);
            container.BindTransient<PlayerContext, PlayerContext>();
            container.BindSingleton<IMoveStyle, JumpingMoveStyle>();
        }

        private void BindInput(Container container)
        {
#if UNITY_EDITOR
            container.BindInstanceAs<IPlayerChargeInput>(Instantiate(_testInputPrefab));
#elif UNITY_ANDROID || UNITY_IOS
        container.BindInstanceAs<IPlayerChargeInput>(Instantiate(_deviceInputPrefab));
#endif
        }
    }
}