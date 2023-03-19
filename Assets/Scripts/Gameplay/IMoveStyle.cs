using System;
using Gameplay.Configs;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Moving style (jumping, rolling, etc)
    /// </summary>
    public interface IMoveStyle
    {
        void Move(Transform movingTransform, IMovingConfig config, Vector3 position, Action OnMoveFinish);
    }
}