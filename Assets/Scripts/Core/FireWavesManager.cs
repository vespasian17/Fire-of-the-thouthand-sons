using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEngine;

namespace Core
{
    public class FireWavesManager : MonoBehaviour
    {
        public static FireWavesManager Instance { get; private set; }
    
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] public GameSettings gameSettings;  // Ссылка на GameSettings
    
        private float _moveDelay = 0f;

        [Header("Spawn points")]
        [SerializeField] private WallOfBallLogic bottomXStartSpawnPos;
        [SerializeField] private WallOfBallLogic topXStartSpawnPos;
        [SerializeField] private WallOfBallLogic rightZStartSpawnPos;
        [SerializeField] private WallOfBallLogic leftZStartSpawnPos;

        private int _lastWallOfBall;
        private BallSpawner _ballSpawner;
        private List<WallOfBallLogic> _pullOfWalls = new ();

        public int DestroyBallsCount => gameSettings.destroyBallsCount;
        public int NumberOfBalls => gameSettings.numberOfBalls;
        public float SpaceBetweenBalls => gameSettings.spaceBetweenBalls;
        public float WallOfBallSpeed => gameSettings.wallOfBallsSpeed;
        public float DelayBetweenDestroyingBalls => gameSettings.delayBetweenDestroyingBalls / 1000f;
        public float MoveDelay => _moveDelay;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            UpdateSettings(gameSettings);  // Применяем текущие настройки при запуске
        
            _ballSpawner = gameObject.AddComponent<BallSpawner>();
        
            _pullOfWalls.Add(bottomXStartSpawnPos);
            _pullOfWalls.Add(topXStartSpawnPos);
            _pullOfWalls.Add(rightZStartSpawnPos);
            _pullOfWalls.Add(leftZStartSpawnPos);
        }

        public void UpdateSettings(GameSettings newSettings)
        {
            gameSettings = newSettings;
            _moveDelay = Random.Range(gameSettings.wallMinMoveDelay, gameSettings.wallMaxMoveDelay) / 1000f;
        }

        public void BeginSpawnWallsOfBalls()
        {
            StartCoroutine(SpawnWallWithDelay());
        }

        private void CreateRandomWall(float minMoveDelay, float maxMoveDelay)
        {
            _ballSpawner.SpawnBallsInARow(ballPrefab, GetRandomWall());
        }

        private WallOfBallLogic GetRandomWall()
        {
            int currentWall;
            do
            {
                currentWall = Random.Range(0, _pullOfWalls.Count);
            } while (currentWall == _lastWallOfBall);

            _lastWallOfBall = currentWall;
            return _pullOfWalls[currentWall];
        }
    
        private IEnumerator SpawnWallWithDelay()
        {
            while (gameSettings.spawnWallsCount > 0)
            {
                float delayBetweenSpawnWall = Random.Range(gameSettings.minDelayBetweenSpawnWall, gameSettings.maxDelayBetweenSpawnWall) / 1000f;
                CreateRandomWall(gameSettings.wallMinMoveDelay, gameSettings.wallMaxMoveDelay);
                gameSettings.spawnWallsCount--;
                yield return new WaitForSeconds(delayBetweenSpawnWall);
            }
            yield return new WaitForSeconds(7f);
            GameManager.FightPhase.Idle();
        }
    }
}
