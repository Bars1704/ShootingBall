using System;
using Player.Configs;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Moving style (jumping, rolling, etc)
    /// </summary>
    public interface IMoveStyle
    {
        void Move(Transform movingTransform, IMovingConfig config, Vector3 position, Action OnMoveFinish);
    }
}