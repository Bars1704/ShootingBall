namespace Explosions
{
    /// <summary>
    /// Reacts when object hit the explosion
    /// </summary>
    public interface IExplodable
    {
        /// <summary>
        /// Invokes when explosion offends the entity
        /// </summary>
        void OnExploded();
    }
}