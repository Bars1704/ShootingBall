using UnityEngine;

namespace Input
{
    /// <summary>
    /// Player charge input based on Space keyboard key pressing
    /// </summary>
    public class SpaceKeyPlayerChargeInput : SingleActionPlayerChargeInput
    {
        protected override bool IsInputActivated() => UnityEngine.Input.GetKey(KeyCode.Space);
    }
}