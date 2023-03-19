using DG.Tweening;
using UnityEngine;

namespace Player.FSM
{
    /// <summary>
    /// Player jumps ahead in this state
    /// </summary>
    public class RunPlayerState : PlayerStateBase
    {
        private readonly Transform _transform;

        public RunPlayerState(Vector3 target, Transform transform)
        {
            _transform = transform;
        }

        public override void Start()
        {
            MoveForward();
        }

        public override void OnDestroy()
        {
            _transform.DOKill();
        }

        /// <summary>
        /// Moves forward as far as possible (before he hits an obstacle)
        /// </summary>
        private void MoveForward()
        {
            var player = _playerContext.Player;

            var shouldMove = TryGetMovePosition(out var position);

            if (shouldMove)
                player.Mover.Move(player.Transform, player.PlayerConfig.PlayerMovingConfig, position, MoveToIdleState);
            else
                MoveToIdleState();
        }

        /// <summary>
        /// </summary>
        /// <param name="position">Position to move</param>
        /// <returns>true if there is need to move</returns>
        private bool TryGetMovePosition(out Vector3 position)
        {
            var player = _playerContext.Player;
            var ray = new Ray(player.Transform.position, Vector3.forward);
            var mask = LayerMask.GetMask("Obstacle");
            var isObstacleOnTheWay = Physics.SphereCast(ray, player.Scale.Scale, out RaycastHit result, 10000, mask);

            if (isObstacleOnTheWay)
            {
                position = result.point;
                position.x = player.Transform.position.x;
                position.y = player.Transform.position.y;
                position.z -= player.Scale.Scale;
            }
            else
            {
                position = ray.origin + ray.direction * 100;
            }


            return (player.Transform.position - position).sqrMagnitude >= 1f;
        }

        private void MoveToIdleState()
        {
            _playerContext.TransitionTo(new IdlePlayerState());
        }
    }
}