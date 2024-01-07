using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : Projectile
{
    public Vector3 BallMoveDirection
    {
        get;
        set;
    }
    
    private void Update()
    {
        MoveInDirection(BallMoveDirection, GameManager.gameManager.ballsManager.WallOfBallSpeed);        //Передать направление трансформа!
    }

    public void SetBallSize(float ballRadius)
    {
        GetComponent<Transform>().localScale *= ballRadius;
    }

    public void MoveInDirection(Vector3 directionMove, float speed)
    {
        transform.position += directionMove * speed * Time.deltaTime;
    }
    //rotate
}
