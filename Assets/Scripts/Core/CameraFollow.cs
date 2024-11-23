using UnityEngine;

namespace Core
{
    /// <summary>
    /// Класс CameraFollow отвечает за следование камеры за игроком.
    /// </summary>
    public class CameraFollow : MonoBehaviour
    {
        [Tooltip("Объект игрока, за которым будет следовать камера")]
        public GameObject playerObject;
        private Vector3 _offset;

        private void Start()
        {
            if (playerObject == null)
            {
                Debug.LogError("Player object is not assigned.");
                return;
            }
        
            _offset = transform.position - playerObject.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = playerObject.transform.position + _offset;
        }
    }
}