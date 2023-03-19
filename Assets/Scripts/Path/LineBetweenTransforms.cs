using UnityEngine;

namespace Path
{
    
    /// <summary>
    /// Position <see cref="_lineRenderer"/> between transforms
    /// </summary>
    [RequireComponent(typeof(LineRenderer))]
    public class LineBetweenTransforms : MonoBehaviour
    {
        [SerializeField] private float _yLevel;
        [SerializeField] private Transform[] _transforms;

        private LineRenderer _lineRenderer;

        private void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.positionCount = _transforms.Length;
            _lineRenderer.useWorldSpace = true;
        }

        private void LateUpdate()
        {
            for (int i = 0; i < _transforms.Length; i++)
            {
                var newPos = _transforms[i].position;
                newPos.y = _yLevel;
                _lineRenderer.SetPosition(i, newPos);

            }
        
        }
    }
}