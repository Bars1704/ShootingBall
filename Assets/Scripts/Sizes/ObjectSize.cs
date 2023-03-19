using System;
using UnityEngine;

namespace Sizes
{
    public class ObjectSize : MonoBehaviour
    {
        public Action<float> OnSizeChanged;
        private float _value;
        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                OnSizeChanged?.Invoke(_value);
            }
        }
    }
}