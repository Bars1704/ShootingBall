namespace Input
{
    /// <summary>
    /// Player charge input based on screen touching
    /// </summary>
    public class ScreenTouchPlayerChargeInput : SingleActionPlayerChargeInput
    {
        protected override bool IsInputActivated() => UnityEngine.Input.touchCount > 0;
    }
}