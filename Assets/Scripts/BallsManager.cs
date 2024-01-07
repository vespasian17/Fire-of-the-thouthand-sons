using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

public class BallsManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    
    [SerializeField] private float spaceBetweenBalls = 0.2f;
    [SerializeField] private int numberOfBalls = 20;
    [SerializeField] private float wallOfBallsSpeed = 1;
    [SerializeField] private int minDelayBetweenSpawnWall = 3;
    [SerializeField] private int maxDelayBetweenSpawnWall = 5;
    [SerializeField] private int destroyBallsCount = 10;
    [SerializeField] private float wallMinMoveDelay = 10;
    [SerializeField] private float wallMaxMoveDelay = 10;
    [SerializeField] private float spawnWallsCount = 10;
    
    [SerializeField] private WallOfBallLogic bottomXStartSpawnPos;
    [SerializeField] private WallOfBallLogic topXStartSpawnPos;
    [SerializeField] private WallOfBallLogic rightZStartSpawnPos;
    [SerializeField] private WallOfBallLogic leftZStartSpawnPos;

    private BallSpawner _ballSpawner;
    private List<WallOfBallLogic> _pullOfWalls = new();

    public float WallOfBallSpeed
    {
        get => wallOfBallsSpeed;
        set => wallOfBallsSpeed = value;
    }


    private void Awake()
    {
        _ballSpawner = this.AddComponent<BallSpawner>();
        
        _pullOfWalls.Add(bottomXStartSpawnPos);
        _pullOfWalls.Add(topXStartSpawnPos);
        _pullOfWalls.Add(rightZStartSpawnPos);
        _pullOfWalls.Add(leftZStartSpawnPos);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeginSpawnWallsOfBalls()
    {
        StartCoroutine(SpawnWallWithDelay());
    }

    public void CreateRandomWall(float minMoveDelay, float maxMoveDelay)
    {
        _ballSpawner.SpawnBallsInARow(ballPrefab, spaceBetweenBalls, numberOfBalls, GetRandomWall());
    }

    public WallOfBallLogic GetRandomWall()
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
