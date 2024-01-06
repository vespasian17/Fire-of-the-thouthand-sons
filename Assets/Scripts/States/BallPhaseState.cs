using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhaseState : State
{
    
    public override void EndBallPhase()
    {
        Debug.Log("End Ball Phase");
        this._context.TransitionTo(new IdlePhaseState());
    }

    public override void StartBallPhase()
    {
        Debug.Log("Ball Phase");
    }

    public override void ResumeGame()
    {
        Debug.Log("Игра резюм");
    }
}
