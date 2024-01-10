using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private const float ArenaSize = 28.5f;
    private Vector3 _spawnPosition;

    private void Awake()
    {
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void SpawnBallsInARow(GameObject ballPrefab, WallOfBallLogic wall)
    {
        var ballDiameter = GetBallDiameter(BallsManager.ballsManager.SpaceBetweenBalls, BallsManager.ballsManager.NumberOfBalls);         // Get diameter of ball (we need it for filling wall with X number of ball)

        _spawnPosition = GetFirstBallSpawnPoint(wall, ballDiameter);                                         // Get spawn point for first ball
        var ballsContainer = Instantiate(wall.transform);                                           // Create 1-wall container for balls
        
        for (int i = 0; i < BallsManager.ballsManager.NumberOfBalls; i++)                                                   // Cycle that creating X balls in a row
        {
            var createdBall = Instantiate(ballPrefab, ballsContainer);                              // Create 1 ball
            createdBall.transform.position = _spawnPosition;                                                  // Set position of ball  
            var ballConfig = createdBall.GetComponent<Ball>();                                                  // Get Ball() component which contains ball info
            wall.AddBallToDestroyList(ballConfig);                                                   // Add ball to List (List where will destroy X number of balls)
            ballConfig.BallMoveDirection = wall.GetMoveDirection();                                             // Set move direction of ball
            ballConfig.SetBallSize(ballDiameter);                                                       // Set ball size based on ballDiameter
            _spawnPosition += (ballDiameter + BallsManager.ballsManager.SpaceBetweenBalls) * wall.GetSpawnDirectionOfWallBall();  // Update spawn position
        }
        wall.GetBallDestroyer().DestroyRandomBalls(BallsManager.ballsManager.DelayBetweenDestroyingBalls, BallsManager.ballsManager.MoveDelay, BallsManager.ballsManager.DestroyBallsCount, wall.GetListOfBalls());    // Destroy X number of balls (add it to wallOfBallLogic or BallsDestroyer class in future)
    }

    private float GetBallDiameter(float spaceBetweenBalls, int numberOfBalls)                            // Define diameter of ball depend on arena size and number of balls
    {
        return (ArenaSize - (spaceBetweenBalls * numberOfBalls - spaceBetweenBalls)) / numberOfBalls;
    }

    private Vector3 GetFirstBallSpawnPoint(WallOfBallLogic wallOfBall, float ballDiameter)          // Return first spawn point with offsets depend on ball diameter
    {
        var spawnPosition = wallOfBall.WallOfBallSpawnPoint;
        spawnPosition.y = ballDiameter / 2;
        if (wallOfBall.GetSpawnDirectionOfWallBall().x > 0f) spawnPosition.x += ballDiameter / 2;
        if (wallOfBall.GetSpawnDirectionOfWallBall().z > 0f) spawnPosition.z += ballDiameter / 2;
        return spawnPosition;
    }
}
