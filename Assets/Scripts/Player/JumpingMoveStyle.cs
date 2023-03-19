using System;
using DG.Tweening;
using Player.Configs;
using UnityEngine;

namespace Player
{
    public class JumpingMoveStyle : IMoveStyle
    {
        private PlayerConfig _config;

        public JumpingMoveStyle(PlayerConfig config)
        {
            _config = config;
        }

        public void Move(Transform movingTransform, IMovingConfig config, Vector3 position, Action OnMoveFinish)
        {
            var jumpDistance = (position - movingTransform.position).magnitude;
            var jumpHeight = config.JumpHeight;
            var jumpCount = Mathf.CeilToInt(jumpDistance / config.JumpMaxLenght);
            var jumpTime = jumpDistance / config.JumpSpeed;

            movingTransform.DOJump(position, jumpHeight, jumpCount, jumpTime)
                .SetLink(movingTransform.gameObject)
                .SetDelay(config.AwaitBeforeMove)
                .SetEase(Ease.Linear)
                .onComplete += OnMoveFinish.Invoke;
        }
    }
}