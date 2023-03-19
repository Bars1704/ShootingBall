using Player.Configs;
using Player.FSM;
using Reflex.Scripts.Attributes;
using Restorables;
using Sizes;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(ObjectScale), typeof(Mortal))]
    public class Player : MonoBehaviour,IRestorable
    {
        public Sizes.ObjectSize ObjectSize { get; private set; }

        public Transform Transform { get; private set; }
        public PlayerConfig PlayerConfig { get; private set; }

        public ObjectScale Scale { get; private set; }

        public IMoveStyle Mover { get; private set; }

        public Mortal Mortal { get; private set; }

        private PlayerContext _playerContext;

        [Inject]
        private void Inject(PlayerContext playerContext, PlayerConfig playerConfig, IMoveStyle moveStyle)
        {
            PlayerConfig = playerConfig;
            Mover = moveStyle;
            _playerContext = playerContext;
            _playerContext.Player = this;
        }

        private void Awake()
        {
            ObjectSize = GetComponent<Sizes.ObjectSize>();
            Scale = GetComponent<ObjectScale>();
            Mortal = GetComponent<Mortal>();
            Transform = transform;
            Restore();
        }

        public void Restore()
        {
            ObjectSize.Value = PlayerConfig.PlayerSize;
            _playerContext.TransitionTo(new IdlePlayerState());
        }
    }
}