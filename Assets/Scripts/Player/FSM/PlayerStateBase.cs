namespace Player.FSM
{
    /// <summary>
    /// Player SFM base type
    /// </summary>
    public abstract class PlayerStateBase : IState
    {
        protected PlayerContext _playerContext;

        public void SetContext(PlayerContext ctx)
        {
            _playerContext = ctx;
        }

        public abstract void Start();


        public abstract void OnDestroy();
    }
}