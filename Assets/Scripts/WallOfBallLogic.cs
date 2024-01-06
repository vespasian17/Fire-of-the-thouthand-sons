using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WallOfBallLogic : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Vector3 spawnPosition;

    private Vector3 SpawnPosition
    {
        get => spawnPosition;
        set => spawnPosition = value;
    }
    
    public WallOfBallLogic(Vector3 spawnPosition)
    {
        this.spawnPosition = spawnPosition;
    }
    public Vector3 GetSpawnDirectionOfWallBall()
    {
        return direction;
    }

    public Transform GetWallTransform()
    {
        return GetComponent<Transform>();
    }
}
