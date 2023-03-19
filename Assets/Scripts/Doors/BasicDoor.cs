using DG.Tweening;
using UnityEngine;

namespace Doors
{
    public class BasicDoor : MonoBehaviour, IDoor
    {
        [SerializeField] private Transform _doorPivot;
        [SerializeField] private Vector3 _openedRotationAngle;
        [SerializeField] private Vector3 _closedRotationAngle;
        [SerializeField] private float _rotationTime;

        public bool IsOpened { get; private set; }

        public void Open() => SetOpened(true);

        public void Close() => SetOpened(false);

        public void SetOpened(bool isOpened)
        {
            var rotationAnlge = isOpened ? _openedRotationAngle : _closedRotationAngle;
            _doorPivot.DORotate(rotationAnlge, _rotationTime);
            IsOpened = isOpened;
        }
    }
}