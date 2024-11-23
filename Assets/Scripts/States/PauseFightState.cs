using UnityEngine;

/// <summary>
/// Класс PauseFightState отвечает за поведение во время паузы боя.
/// </summary>
public class PauseFightState : State
{
    /// <summary>
    /// Завершает фазу с шарами в состоянии паузы боя.
    /// </summary>
    public override void EndBallPhase()
    {
        Debug.LogError("EndBallPhase is not implemented in PauseFightState.");
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Запускает фазу с шарами в состоянии паузы боя.
    /// </summary>
    public override void StartBallPhase()
    {
        Debug.LogError("StartBallPhase is not implemented in PauseFightState.");
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Возобновляет игру после паузы.
    /// </summary>
    public override void ResumeGame()
    {
        Debug.Log("PauseFightState handles ResumeGame.");
        Debug.Log("PauseFightState wants to change the state of the context.");
        if (_context != null)
        {
            _context.TransitionTo(new BallPhaseState());
        }
        else
        {
            Debug.LogError("Context is not set in PauseFightState.");
        }
    }
}