using Restorables;
using UnityEngine;

namespace Levels
{
    public class SetActiveOnRestore : MonoBehaviour, IRestorable
    {
        public void Restore()
        {
            gameObject.SetActive(true);
        }
    }
}