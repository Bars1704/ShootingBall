namespace Player.FSM
{
    /// <summary>
    /// FSM state
    /// </summary>
    public interface IState
    {
        public void Start();
        public void SetContext(PlayerContext ctx);
        public void OnDestroy();
    }
}