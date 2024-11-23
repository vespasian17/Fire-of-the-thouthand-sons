using System.Collections;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// Класс CameraController отвечает за управление зумом камеры.
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Settings")]
        [SerializeField] private float zoomSpeed = 1f; 
        [SerializeField] private float ballPhaseZoom = 8f; 
        [SerializeField] private float idlePhaseZoom = 5f; 

        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            if (_camera == null)
            {
                Debug.LogError("Camera component is missing on the GameObject.");
            }
        }

        /// <summary>
        /// Увеличивает зум камеры.
        /// </summary>
        public void CameraZoomOut()
        {
            StopAllCoroutines();
            StartCoroutine(CameraZoom(ballPhaseZoom));
        }

        /// <summary>
        /// Уменьшает зум камеры.
        /// </summary>
        public void CameraZoomIn()
        {
            StopAllCoroutines();
            StartCoroutine(CameraZoom(idlePhaseZoom));
        }

        /// <summary>
        /// Корутина для плавного изменения зума камеры.
        /// </summary>
        /// <param name="targetZoom">Целевое значение зума.</param>
        private IEnumerator CameraZoom(float targetZoom)
        {
            float from = _camera.orthographicSize;
            float time = 0;

            while (time < 1f)
            {
                time += zoomSpeed * Time.deltaTime;
                _camera.orthographicSize = Mathf.Lerp(from, targetZoom, time);

                yield return null;
            }

            _camera.orthographicSize = targetZoom;
        }
    }
}