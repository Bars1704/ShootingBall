using DG.Tweening;
using Sizes;
using UnityEngine;

namespace VFX
{
    /// <summary>
    /// Creates explosion effect
    /// </summary>
    [RequireComponent(typeof(ObjectSize))]
    public class ExplosionEffect : MonoBehaviour
    {
        private ObjectSize _size;

        public void Explode(float explosionSize, float animationTime)
        {
            _size = _size == default ? GetComponent<ObjectSize>() : _size;

            _size.Value = 0;
            gameObject.SetActive(true);

            DOTween.To(
                    () => _size.Value,
                    value => _size.Value = value,
                    explosionSize,
                    animationTime)
                .SetLink(gameObject)
                .SetEase(Ease.Linear)
                .onComplete += () => gameObject.SetActive(false);
        }
    }
}