using UnityEngine;

namespace Explosions
{
    /// <summary>
    /// Disable object when explosion hits
    /// </summary>
    [RequireComponent(typeof(Exploding))]
    public class DisableOnExplosion : MonoBehaviour
    {
        private Exploding _explodeOnCollision;

        private void Start()
        {
            _explodeOnCollision = GetComponent<Exploding>();

            _explodeOnCollision.OnExploded += Disable;
        }

        private void OnDestroy()
        {
            if (_explodeOnCollision != default)
                _explodeOnCollision.OnExploded -= Disable;
        }

        private void Disable(Vector3 _)
        {
            gameObject.SetActive(false);
        }
    }
}