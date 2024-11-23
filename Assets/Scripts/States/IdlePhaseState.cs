using UnityEngine;

/// <summary>
/// Класс IdlePhaseState отвечает за поведение во время фазы ожидания.
/// </summary>
public class IdlePhaseState : State
{
    /// <summary>
    /// Завершает фазу с шарами в режиме ожидания.
    /// </summary>
    public override void EndBallPhase()
    {
        Debug.Log("End Ball Phase in Idle State");
    }

    /// <summary>
    /// Запускает фазу с шарами и переходит в соответствующее состояние.
    /// </summary>
    public override void StartBallPhase()
    {
        Debug.Log("Starting Ball Phase");
        if (_context != null)
        {
            _context.TransitionTo(new BallPhaseState());
        }
        else
        {
            Debug.LogError("Context is not set in IdlePhaseState.");
        }
    }

    /// <summary>
    /// Возобновляет игру после паузы.
    /// </summary>
    public override void ResumeGame()
    {
        Debug.Log("Resuming game in Idle State");
    }
}