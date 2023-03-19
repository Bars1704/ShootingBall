using Restorables;
using Sizes;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Letting object down to touch the ground when it change his size
    /// </summary>
    [RequireComponent(typeof(Sizes.ObjectSize), typeof(ObjectScale))]
    public class StickToGround : MonoBehaviour, IRestorable
    {
        private ObjectScale _sizeWithScale;
        private Sizes.ObjectSize _objectSize;
        private Transform _transform;

        private float _previousScale;
        private Vector3 defaultPosition;

        void Start()
        {
            _transform = transform;
            _objectSize = GetComponent<Sizes.ObjectSize>();
            _sizeWithScale = GetComponent<ObjectScale>();
            _objectSize.OnSizeChanged += RecalculatePosition;

            _previousScale = _sizeWithScale.Scale;

            RaycastStick();
            defaultPosition = transform.position;
        }

        private void OnDestroy()
        {
            _objectSize.OnSizeChanged -= RecalculatePosition;
        }

        /// <summary>
        /// Sticks object to ground, basing ob raycast to the bottom
        /// </summary>
        public void RaycastStick()
        {
            Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, float.PositiveInfinity);
            transform.position = hit.point + (Vector3.up * _sizeWithScale.Scale * 0.5f);
        }

        /// <summary>
        /// Recalculates position, basing on new scale value
        /// </summary>
        /// <param name="_"></param>
        private void RecalculatePosition(float _)
        {
            var scaleDelta = _sizeWithScale.Scale - _previousScale;
            _transform.Translate(Vector3.up * (scaleDelta * 0.5f));
            _previousScale = _sizeWithScale.Scale;
        }

        public void Restore()
        {
            transform.position = defaultPosition;
        }
    }
}