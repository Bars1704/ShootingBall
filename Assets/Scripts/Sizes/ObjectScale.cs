using System;
using UnityEngine;

namespace Sizes
{
    /// <summary>
    /// Synchronizes entity scale with its size
    /// </summary>
    [RequireComponent(typeof(Sizes.ObjectSize))]
    public class ObjectScale : MonoBehaviour
    {
        [SerializeField] [Tooltip("size to scale ratio: for example, if coef set to 2 and size if 5, scale will be 10")]
        private float _sizeToScaleCoefficient;

        public event Action<float> OnScaleChanged;
        public float Scale => _sizeToScaleCoefficient * _objectSize.Value;

        private Transform _transform;
        private Sizes.ObjectSize _objectSize;


        private void Awake()
        {
            _transform = transform;
            _objectSize = GetComponent<Sizes.ObjectSize>();
            _objectSize.OnSizeChanged += OnSizeChanged;
            OnSizeChanged(_objectSize.Value);
        }

        private void OnDestroy()
        {
            _objectSize.OnSizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(float size)
        {
            _transform.localScale = Vector3.one * Scale;
            OnScaleChanged?.Invoke(Scale);
        }
    }
}