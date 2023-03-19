using UnityEngine;

namespace Explosions
{
    /// <summary>
    /// Constantly moves in the set direction
    /// </summary>
    public class ConstantMove : MonoBehaviour
    {
        [SerializeField] private Vector3 Direction;
        private Transform _transform;

        private void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.Translate(Direction * Time.deltaTime);
        }
    }
}