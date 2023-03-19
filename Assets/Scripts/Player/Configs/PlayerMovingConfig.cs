using UnityEngine;

namespace Player.Configs
{
    [CreateAssetMenu(menuName = "ShootingBall/PlayerMovingConfig")]
    public class PlayerMovingConfig : ScriptableObject, IMovingConfig
    {
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _jumpMaxLenght;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _awaitBeforeMove;


        public float AwaitBeforeMove => _awaitBeforeMove;
        public float JumpSpeed => _jumpSpeed;
        public float JumpHeight => _jumpHeight;
        public float JumpMaxLenght => _jumpMaxLenght;
    }
}