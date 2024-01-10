using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BallsDestroyer : MonoBehaviour
{
    private Random _random;

    private void Awake()
    {
        _random = new Random();
    }
    

    public void DestroyRandomBalls(float delay, float moveDelay, int numberOfBallToDestroy,  List<Ball> oneWallBallsContainer)
    {
        StartCoroutine(DestroyRandomBallsWithDelayFromList(delay, moveDelay, numberOfBallToDestroy, oneWallBallsContainer));
    }
    
    private IEnumerator DestroyRandomBallsWithDelayFromList(float delayBetweenDestroyBalls, float moveDelay, int numberOfBallToDestroy, List<Ball> oneWallBallsContainer)         
    {
        yield return new WaitForSeconds(moveDelay);
        while (numberOfBallToDestroy > 0)
        {
            DestroyRandomBallFromList(oneWallBallsContainer);
            numberOfBallToDestroy--;
            yield return new WaitForSeconds(delayBetweenDestroyBalls);
        }
    }

    public void DestroyRandomBallFromList(List<Ball> oneWallBallsContainer)
    {
        int randomBall = 0;
        randomBall = _random.Next(0, oneWallBallsContainer.Count);
        if (oneWallBallsContainer[randomBall])
        {
            Destroy(oneWallBallsContainer[randomBall].gameObject);
        }
        oneWallBallsContainer.RemoveAt(randomBall);
    }
}
