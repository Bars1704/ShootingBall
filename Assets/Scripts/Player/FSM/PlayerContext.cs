using Input;
using Miscellaneous;

namespace Player.FSM
{
    /// <summary>
    /// Finite state machine realization for player
    /// </summary>
    public class PlayerContext
    {
        public IPlayerChargeInput PlayerChargeInput { get; }
        public ObjectPool<Bullet> BulletsPool { get; }
        public global::Player.Player Player { get; set; }

        // A reference to the current state of the Context.
        private IState _state = null;

        public PlayerContext(IPlayerChargeInput playerChargeInput, ObjectPool<Bullet> bulletsPool)
        {
            PlayerChargeInput = playerChargeInput;
            BulletsPool = bulletsPool;
        }


        // The Context allows changing the State object at runtime.
        public void TransitionTo(IState state)
        {
            _state?.OnDestroy();
            _state = state;
            _state.SetContext(this);
            _state.Start();
        }
    }
}