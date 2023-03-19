using Sizes;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Kill entity if its size is too small, using <see cref="Mortal"/>
    /// </summary>
    [RequireComponent(typeof(Mortal), typeof(ObjectSize))]
    public class DieFromSmallSize : MonoBehaviour
    {
        [SerializeField] private float _minSize;

        private Mortal _mortal;
        private ObjectSize _size;

        void Start()
        {
            _size = GetComponent<ObjectSize>();
            _mortal = GetComponent<Mortal>();

            _size.OnSizeChanged += OnSizeChanged;
        }

        private void OnDestroy()
        {
            _size.OnSizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(float size)
        {
            if (size < _minSize)
                _mortal.Die();
        }
    }
}