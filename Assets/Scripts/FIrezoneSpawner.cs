using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using Random = System.Random;

public class FirezoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject firezonePrefab;
    [SerializeField] private int quadGridOfFirezone = 10;                               // number of firezones within 1 line
    [SerializeField] private int firezoneMaxSnakeSteps = 10;
    [SerializeField] private float spaceBetweenFirezones = 0.2f;
    [SerializeField] private float firezoneSnakeSpeed = 1000;                          // ms
    [SerializeField] private bool bordersOffset;

    private float firezoneSize;                                                         // 1 side of quad
    private float FirezoneSize
    {
        get => firezoneSize;
        set => firezoneSize = value;
    }

    private List<Vector3> firstSpawnPointsList = new();

    private Random random;

    private void Start()
    {
        random = new Random();
        DefineFirezoneSize();
        DefineFirezoneSpawnPoints();
    }

    private void SpawnFirezoneInRandomPosition()
    {
        int randomPosToSpawn = random.Next(0, firstSpawnPointsList.Count);
        StartSnakeSpawnFirezone(firstSpawnPointsList[randomPosToSpawn]);
    }
    

    private void CreateNewFirezone()
    {
        
    }

    private void AddPositionToFirstSpawnPointList(Vector3 spawnPoint)
    {
        firstSpawnPointsList.Add(spawnPoint);
    }

    private void DefineFirezoneSpawnPoints()                                            // 4 zones in corners of quad
    {
        var boundsMax = Arena.ArenaBounds.max;
        boundsMax.x -= spaceBetweenFirezones + FirezoneSize / 2f;
        boundsMax.z -= spaceBetweenFirezones + FirezoneSize / 2f;
        
        var boundsMin = Arena.ArenaBounds.min;
        boundsMin.x += spaceBetweenFirezones + FirezoneSize / 2f;
        boundsMin.z += spaceBetweenFirezones + FirezoneSize / 2f;
        
        var spawnPoint = new Vector3(boundsMax.x, 0, boundsMax.z);             // find position of arena corner
        AddPositionToFirstSpawnPointList(spawnPoint);
        spawnPoint = new Vector3(boundsMax.x, 0, boundsMin.z);
        AddPositionToFirstSpawnPointList(spawnPoint);
        spawnPoint = new Vector3(boundsMin.x, 0, boundsMax.z);
        AddPositionToFirstSpawnPointList(spawnPoint);
        spawnPoint = new Vector3(boundsMin.x, 0, boundsMin.z);
        AddPositionToFirstSpawnPointList(spawnPoint);
    }

    private void DefineFirezoneSize()
    {
        if (bordersOffset)
        {
            FirezoneSize = (GameManager.ArenaSize - ((quadGridOfFirezone + 1) * spaceBetweenFirezones)) /
                           quadGridOfFirezone;
            firezonePrefab.GetComponent<Transform>().localScale *= FirezoneSize;
        }
        else
        {
            FirezoneSize = (GameManager.ArenaSize - ((quadGridOfFirezone - 1) * spaceBetweenFirezones)) /
                           quadGridOfFirezone;
            firezonePrefab.GetComponent<Transform>().localScale *= FirezoneSize;
        }
    }
    

    IEnumerator StartSnakeSpawnFirezone(Vector3 spawnPosition)              // try async/await
    {
        List<Vector3> listOfSpawnedFirezones = new List<Vector3>();
        yield return new WaitForSeconds(firezoneSnakeSpeed/1000f);
    }
}
