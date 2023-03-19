using UnityEngine;

namespace Explosions
{
    [RequireComponent(typeof(Exploding))]
    public class ExplodeOnCollision : MonoBehaviour
    {
        private Exploding _exploding;

        private void Start()
        {
            _exploding = GetComponent<Exploding>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _exploding?.Explode();
        }
    }
}