using UnityEngine;

namespace Core
{
    /// <summary>
    /// Класс Arena отвечает за хранение границ арены.
    /// </summary>
    public class Arena : MonoBehaviour
    {
        private static Bounds _arenaBounds;

        /// <summary>
        /// Границы арены.
        /// </summary>
        public static Bounds ArenaBounds
        {
            get => _arenaBounds;
            private set => _arenaBounds = value;
        }

        void Awake()
        {
            Collider arenaCollider = GetComponent<Collider>();
            if (arenaCollider != null)
            {
                ArenaBounds = arenaCollider.bounds;
            }
            else
            {
                Debug.LogError("Collider component is missing on the Arena object.");
            }
        }
    }
}

