using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFightState : State
{

    public override void EndBallPhase()
    {
        throw new System.NotImplementedException();
    }

    public override void StartBallPhase()
    {
        throw new System.NotImplementedException();
    }

    public override void ResumeGame()
    {
        Debug.Log("IdlePhaseState handles ResumeGame.");
        Debug.Log("IdlePhaseState wants to change the state of the context.");
        this._context.TransitionTo(new BallPhaseState());
    }
}
