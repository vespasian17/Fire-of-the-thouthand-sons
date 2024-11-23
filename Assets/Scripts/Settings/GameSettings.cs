using UnityEngine;

namespace Settings
{
    public class GameSettings : MonoBehaviour
    {
        public static GameSettings Instance { get; private set; }

        [Header("Speed Settings")]
        public float wallOfBallsSpeed = 5f;

        [Header("Time Settings (ms)")]
        public int minDelayBetweenSpawnWall = 1500;
        public int maxDelayBetweenSpawnWall = 1500;
        public int wallMinMoveDelay = 1000;
        public int wallMaxMoveDelay = 4000;
        public float delayBetweenDestroyingBalls = 300f;

        [Header("Wall and Ball Settings")]
        public float spaceBetweenBalls = 0.2f;
        public int numberOfBalls = 20;
        public int destroyBallsCount = 10;
        public float spawnWallsCount = 10f;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}