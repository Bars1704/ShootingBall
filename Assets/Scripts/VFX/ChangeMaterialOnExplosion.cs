using Explosions;
using Restorables;
using UnityEngine;

namespace VFX
{
    /// <summary>
    /// Change object material when explosion hits
    /// </summary>
    [RequireComponent(typeof(Renderer))]
    public class ChangeMaterialOnExplosion : MonoBehaviour, IExplodable, IRestorable
    {
        [SerializeField] private Material _material;

        private Renderer _renderer;

        private Material _defaultMaterial;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _defaultMaterial = _renderer.material;
        }

        public void OnExploded()
        {
            _renderer.material = _material;
        }

        public void Restore()
        {
            _renderer.material = _defaultMaterial;
        }
    }
}