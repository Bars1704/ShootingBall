using System;
using Gameplay;
using Miscellaneous;
using Restorables;
using UnityEngine;

namespace Levels
{
    public class Level : MonoBehaviour
    {
        /// <summary>
        /// Invokes, when player wins
        /// </summary>
        public event Action OnGameWin;

        /// <summary>
        /// Invokes, when player loses
        /// </summary>
        public event Action OnGameLose;

        private Vector3 playerDefaultPosition;

        [SerializeField] private Player _player;
        [SerializeField] private OnTriggerEnterEvent _winZone;

        private IRestorable[] _restorables;

        private void Start()
        {
            _winZone.OnTriggerEntered += Win;
            _player.Mortal.OnDied += Lose;
            _restorables = GetComponentsInChildren<IRestorable>();
        }

        private void Win(Collider _)
        {
            OnGameWin?.Invoke();
            ResetLevel();
        }

        private void Lose()
        {
            OnGameLose?.Invoke();
            ResetLevel();
        }

        private void ResetLevel()
        {
            _restorables.ForEach(x => x.Restore());
        }
    }
}