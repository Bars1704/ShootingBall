using Sizes;
using UnityEngine;

namespace Path
{
    /// <summary>
    /// Sync <see cref="_lineRenderer"/> width according to object scalse
    /// </summary>
    [RequireComponent(typeof(LineRenderer))]
    public class SyncLineScale : MonoBehaviour
    {
        [SerializeField] private ObjectScale _scale;

        private LineRenderer _lineRenderer;

        private void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _scale.OnScaleChanged += SyncScale;
            SyncScale(_scale.Scale);
        }

        private void SyncScale(float newScale)
        {
            _lineRenderer.widthMultiplier = newScale;
        }
    }
}