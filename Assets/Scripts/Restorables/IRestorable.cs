namespace Restorables
{
    public interface IRestorable
    {
        /// <summary>
        /// Restore object default state
        /// </summary>
        public void Restore();
    }
}