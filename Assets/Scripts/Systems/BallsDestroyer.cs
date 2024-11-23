using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsDestroyer : MonoBehaviour
{
    public void DestroyRandomBalls(float delay, float moveDelay, int numberOfBallToDestroy, List<Ball> oneWallBallsContainer)
    {
        CleanUpNullsFromList(oneWallBallsContainer);
        StartCoroutine(DestroyRandomBallsWithDelayFromList(delay, moveDelay, numberOfBallToDestroy, oneWallBallsContainer));
    }
    
    private IEnumerator DestroyRandomBallsWithDelayFromList(float delayBetweenDestroyBalls, float moveDelay, int numberOfBallToDestroy, List<Ball> oneWallBallsContainer)
    {
        yield return new WaitForSeconds(moveDelay);
        while (numberOfBallToDestroy > 0 && oneWallBallsContainer.Count > 0)
        {
            DestroyRandomBallFromList(oneWallBallsContainer);
            numberOfBallToDestroy--;
            yield return new WaitForSeconds(delayBetweenDestroyBalls);
        }
    }

    public void DestroyRandomBallFromList(List<Ball> oneWallBallsContainer)
    {
        if (oneWallBallsContainer.Count == 0) return;

        int randomBallIndex = Random.Range(0, oneWallBallsContainer.Count);
        Ball selectedBall = oneWallBallsContainer[randomBallIndex];
        
        oneWallBallsContainer.RemoveAt(randomBallIndex);
        
        if (selectedBall != null)
        {
            Destroy(selectedBall.gameObject);
        }
    }

    private void CleanUpNullsFromList(List<Ball> oneWallBallsContainer)
    {
        oneWallBallsContainer.RemoveAll(ball => ball == null);
    }
}