using System;
using UnityEngine;

public class Ball : Projectile
{
    private float initializationTime;

    private void Start()
    {
        initializationTime = Time.time;
    }

    public Vector3 BallMoveDirection
    {
        get;
        set;
    }
    
    private void Update()
    {
        if (!(Time.time - initializationTime < BallsManager.ballsManager.MoveDelay))                // refactor this shit in future
        {
            MoveInDirection(BallMoveDirection, BallsManager.ballsManager.WallOfBallSpeed);
        }
 
    }

    public void SetBallSize(float ballRadius)
    {
        GetComponent<Transform>().localScale *= ballRadius;
    }

    private void MoveInDirection(Vector3 directionMove, float speed)
    {
        transform.position += directionMove * (speed * Time.deltaTime);
    }
    //rotate
}
