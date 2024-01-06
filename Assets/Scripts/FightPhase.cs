using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPhase
{
    private State _state = null;
    public delegate void FightPhaseHandler(State state);
    public event FightPhaseHandler Notify;
    
    public FightPhase(State state)
    {
        this.TransitionTo(state);
    }
    
    public void TransitionTo(State state)
    {
        Debug.Log($"Context: Transition to {state.GetType().Name}.");
        this._state = state;
        this._state.SetContext(this);
        Notify?.Invoke(_state);
    }

    public void Idle()
    {
        this._state.EndBallPhase();
    }

    public void BallPhase()
    {
        this._state.StartBallPhase();
    }
    
    public void Pause()
    {
        this._state.ResumeGame();
    }

    public State GetCurrentState() => _state;
}
