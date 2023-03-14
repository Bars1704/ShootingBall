using System;
using DG.Tweening;
using UnityEngine;

public class BasicDoor : MonoBehaviour, IDoor
{
    [SerializeField] private Transform _doorPivot;
    [SerializeField] private Vector3 _openedRotationAngle;
    [SerializeField] private Vector3 _closedRotationAngle;
    [SerializeField] private float _rotationTime;

   /// <inheritdoc cref="IDoor.IsOpened"/>
    public bool IsOpened { get; private set; }
    
   /// <inheritdoc cref="IDoor.Open"/>

    public void Open() => SetOpened(true);

   /// <inheritdoc cref="IDoor.Close"/>

    public void Close() => SetOpened(false);

   /// <inheritdoc cref="IDoor.SetOpened"/>
   public void SetOpened(bool isOpened)
    {
        var rotationAnlge = isOpened ? _openedRotationAngle : _closedRotationAngle;
        _doorPivot.DORotate(rotationAnlge, _rotationTime);
        IsOpened = isOpened;
    }
}