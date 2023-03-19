namespace Gameplay.Configs
{
    public interface IMovingConfig
    {
        /// <summary>
        /// Time, object need to wait before start moving in seconds
        /// </summary>
        float AwaitBeforeMove { get; }
        float JumpSpeed { get; }
        float JumpHeight { get; }
        /// <summary>
        /// Max length, object can cover by one jump
        /// </summary>
        float JumpMaxLenght { get; }
    }
}