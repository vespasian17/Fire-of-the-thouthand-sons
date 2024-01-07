using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private const float ArenaSize = 28.5f;
    private Vector3 _spawnPosition;

    public void SpawnBallsInARow(GameObject ballPrefab, float spaceBetweenBalls, int numberOfBalls, WallOfBallLogic wall)
    {
        var ballDiameter = GetBallDiameter(spaceBetweenBalls, numberOfBalls);                       // Get diameter of ball

        _spawnPosition = GetFirstBallSpawnPoint(wall, ballDiameter);                                    // Get spawn point for first ball
        
        for (int i = 0; i < numberOfBalls; i++)                                                         // Create X balls in a row
        {
            var createdBall = Instantiate(ballPrefab, wall.transform);
            createdBall.transform.position = _spawnPosition;
            var ballConfig = createdBall.GetComponent<Ball>();
            ballConfig.BallMoveDirection = wall.GetMoveDirection();
            ballConfig.SetBallSize(ballDiameter);                                                       // Set ball size based on ballDiameter
            _spawnPosition += (ballDiameter + spaceBetweenBalls) * wall.GetSpawnDirectionOfWallBall();       // Update spawn position
        }
    }

    private GameObject CreateBallContainer()
    {
        return new GameObject();
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
    
    public static void CreateEmptyChild() {
        GameObject go = new GameObject("BallContainer");
 
        if(Selection.activeTransform != null)
        {
            go.transform.parent = Selection.activeTransform;
            go.transform.Translate(Selection.activeTransform.position);
        }
    }
}
