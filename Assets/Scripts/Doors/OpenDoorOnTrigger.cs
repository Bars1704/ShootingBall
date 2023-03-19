using UnityEngine;

namespace Doors
{
    /// <summary>
    /// Open the door when someone comes into trigger
    /// </summary>
    [RequireComponent(typeof(IDoor), typeof(Collider))]
    public class OpenDoorOnTrigger : MonoBehaviour
    {
        private IDoor _door;

        private void Start()
        {
            _door = GetComponent<IDoor>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _door.Open();
        }

        private void OnTriggerExit(Collider other)
        {
            _door.Close();
        }
    }
}