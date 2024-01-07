using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WallOfBallLogic : MonoBehaviour
{
    [SerializeField] private Vector3 spawnDirection;
    [SerializeField] private Vector3 moveDirection;

    public Vector3 WallOfBallSpawnPoint { get; private set; }

    private void Awake()
    {
        WallOfBallSpawnPoint = GetComponent<Transform>().position;
    }

    public Vector3 GetSpawnDirectionOfWallBall()
    {
        return spawnDirection;
    }

    public Transform GetWallTransform()
    {
        return GetComponent<Transform>();
    }

    public Vector3 GetMoveDirection()
    {
        return moveDirection;
    }
}
