namespace Player.FSM
{
    /// <summary>
    /// Player charges in this state, decreasing its own size
    /// </summary>
    public class ChargePlayerState : PlayerStateBase
    {
        private float _chargeAmount;

        public override void Start()
        {
            _playerContext.PlayerChargeInput.OnPlayerChargeProcess += OnPlayerChargeProcess;
            _playerContext.PlayerChargeInput.OnPlayerChargeEnd += OnPlayerChargeEnd;
        }

        public override void OnDestroy()
        {
            _playerContext.PlayerChargeInput.OnPlayerChargeProcess -= OnPlayerChargeProcess;
            _playerContext.PlayerChargeInput.OnPlayerChargeEnd -= OnPlayerChargeEnd;
        }

        private void OnPlayerChargeEnd()
        {
            var bulletSizeMultiplier = _playerContext.Player.PlayerConfig.BulletSizeMultiplier;
            _playerContext.TransitionTo(new ShootPlayerState(_chargeAmount * bulletSizeMultiplier));
        }

        private void OnPlayerChargeProcess(float deltaTime)
        {
            _playerContext.Player.ObjectSize.Value -= deltaTime;
            _chargeAmount += deltaTime;
        }
    }
}