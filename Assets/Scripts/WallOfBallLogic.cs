using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallOfBallLogic : MonoBehaviour
{
    [SerializeField] private Vector3 spawnDirection;
    [SerializeField] private Vector3 moveDirection;
    private List<Ball> _listOfBalls = new ();
    private BallsDestroyer ballsDestroyer;

    public Vector3 WallOfBallSpawnPoint { get; private set; }

    private void Awake()
    {
        WallOfBallSpawnPoint = GetComponent<Transform>().position;
        ballsDestroyer = this.AddComponent<BallsDestroyer>();
    }

    public BallsDestroyer GetBallDestroyer()
    {
        return ballsDestroyer;
    }
    
    public List<Ball> GetListOfBalls()
    {
        return _listOfBalls;
    }
    
    public void AddBallToDestroyList(Ball ball)
    {
        _listOfBalls.Add(ball);
    }

    public Vector3 GetSpawnDirectionOfWallBall()
    {
        return spawnDirection;
    }
    

    public Vector3 GetMoveDirection()
    {
        return moveDirection;
    }
}
