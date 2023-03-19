using System.Collections;
using UnityEngine;

namespace Explosions
{
    [RequireComponent(typeof(Exploding))]
    public class ExplodeAfterTime : MonoBehaviour
    {
        [SerializeField] private float _explodeDelay;
        private Exploding _exploding;
        private Coroutine _timerRoutine;

        private void Start()
        {
            _exploding = GetComponent<Exploding>();
            _exploding.OnExploded += OnExploded;
        }

        private void OnDestroy()
        {
            _exploding.OnExploded -= OnExploded;
        }

        private void OnExploded(Vector3 _)
        {
            if (_timerRoutine != default)
                StopCoroutine(_timerRoutine);
        }

        private void OnEnable()
        {
            _timerRoutine = StartCoroutine(ExplodeAfterSeconds());
        }

        private IEnumerator ExplodeAfterSeconds()
        {
            yield return new WaitForSeconds(_explodeDelay);
            _timerRoutine = default;
            _exploding.Explode();
        }
    }
}