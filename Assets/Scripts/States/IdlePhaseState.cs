using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePhaseState : State
{
    
    public override void EndBallPhase()
    {
        Debug.Log("Шары стоп");
    }

    public override void StartBallPhase()
    {
        Debug.Log("Ну че шары полетели");
        this._context.TransitionTo(new BallPhaseState());
    }

    public override void ResumeGame()
    {
        Debug.Log("Игра  резюм");
    }
}
