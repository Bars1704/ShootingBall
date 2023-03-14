public interface IDoor
{
    /// <summary>
    /// Open the door
    /// </summary>
    void Open();

    /// <summary>
    /// Close the door
    /// </summary>
    void Close();

    /// <summary>
    /// Set door opened or closed, according to isOpened parameter
    /// </summary>
    /// <param name="isOpened">if True - open the door, if False - close it</param>
    void SetOpened(bool isOpened);

    /// <summary>
    /// Is Door opened
    /// </summary>
    bool IsOpened { get; }
}