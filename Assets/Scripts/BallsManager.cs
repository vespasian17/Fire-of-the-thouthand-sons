using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class BallsManager : MonoBehaviour
{
    public static BallsManager ballsManager;
    
    [SerializeField] private GameObject ballPrefab;
    
    [Header("Speed Settings")]
    [SerializeField] private float wallOfBallsSpeed = 1f;
    
    [Header("Time Settings")]
    [SerializeField] private int minDelayBetweenSpawnWall = 3;
    [SerializeField] private int maxDelayBetweenSpawnWall = 5;
    [SerializeField] private int wallMinMoveDelay = 1;
    [SerializeField] private int wallMaxMoveDelay = 4;
    [SerializeField] private float delayBetweenDestroyingBalls = 3f;
    private float moveDelay = 0f;
    
    [Header("Wall and ball Settings")]
    [SerializeField] private float spaceBetweenBalls = 0.2f;
    [SerializeField] private int numberOfBalls = 20;
    [SerializeField] private int destroyBallsCount = 10;
    [SerializeField] private float spawnWallsCount = 10f;

    [Header("Spawn points")]
    [SerializeField] private WallOfBallLogic bottomXStartSpawnPos;
    [SerializeField] private WallOfBallLogic topXStartSpawnPos;
    [SerializeField] private WallOfBallLogic rightZStartSpawnPos;
    [SerializeField] private WallOfBallLogic leftZStartSpawnPos;

    public int DestroyBallsCount
    {
        get => destroyBallsCount;
        private set => destroyBallsCount = value;
    }
    public int NumberOfBalls
    {
        get => numberOfBalls;
        private set => numberOfBalls = value;
    }
    public float SpaceBetweenBalls
    {
        get => spaceBetweenBalls;
        private set => spaceBetweenBalls = value;
    }
    public float WallOfBallSpeed
    {
        get => wallOfBallsSpeed;
        private set => wallOfBallsSpeed = value;
    }
    public float DelayBetweenDestroyingBalls
    {
        get => delayBetweenDestroyingBalls;
        private set => delayBetweenDestroyingBalls = value;
    }

    public float MoveDelay
    {
        get => moveDelay;
    }

    
    private BallSpawner _ballSpawner;
    private List<WallOfBallLogic> _pullOfWalls = new();

    private void Awake()
    {
        ballsManager = this;
    }

    void Start()
    {
        Random random = new Random();
        moveDelay = random.Next(wallMinMoveDelay, wallMaxMoveDelay);            // for all walls. Need to fix random for different walls
        
        _ballSpawner = this.AddComponent<BallSpawner>();
        
        _pullOfWalls.Add(bottomXStartSpawnPos);
        _pullOfWalls.Add(topXStartSpawnPos);
        _pullOfWalls.Add(rightZStartSpawnPos);
        _pullOfWalls.Add(leftZStartSpawnPos);
    }

    // Update is called once per frame
    void Update()
    {

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
        Random random = new Random();
        return _pullOfWalls[random.Next(0, _pullOfWalls.Count)];
    }
    
    private IEnumerator SpawnWallWithDelay()
    {
        var random = new Random();
        
        while (spawnWallsCount > 0)
        {
            var delayBetweenSpawnWall = random.Next(minDelayBetweenSpawnWall, maxDelayBetweenSpawnWall);
            CreateRandomWall(wallMinMoveDelay, wallMaxMoveDelay);
            spawnWallsCount--;
            yield return new WaitForSeconds(delayBetweenSpawnWall);
        }
        GameManager.FightPhase.Idle();
    }
}
