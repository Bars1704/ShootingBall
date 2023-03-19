namespace Gameplay.FSM
{
    public class IdlePlayerState : PlayerStateBase
    {
        public override void Start()
        {
            _playerContext.PlayerChargeInput.OnPlayerChargeBegin += OnPlayerChargeBegin;
        }

        private void OnPlayerChargeBegin()
        {
            _playerContext.TransitionTo(new ChargePlayerState());
        }

        public override void OnDestroy()
        {
            _playerContext.PlayerChargeInput.OnPlayerChargeBegin -= OnPlayerChargeBegin;
        }
    }
}