using UnityEngine;

/// <summary>
/// Класс BallPhaseState отвечает за поведение во время фазы с шарами.
/// </summary>
public class BallPhaseState : State
{
    /// <summary>
    /// Завершает фазу с шарами и переходит в состояние ожидания.
    /// </summary>
    public override void EndBallPhase()
    {
        Debug.Log("End Ball Phase: Transitioning to Idle Phase");
        if (_context != null)
        {
            _context.TransitionTo(new IdlePhaseState());
        }
        else
        {
            Debug.LogError("Context is not set in BallPhaseState.");
        }
    }

    /// <summary>
    /// Запускает фазу с шарами.
    /// </summary>
    public override void StartBallPhase()
    {
        Debug.Log("Start Ball Phase");
    }

    /// <summary>
    /// Возобновляет игру после паузы.
    /// </summary>
    public override void ResumeGame()
    {
        Debug.Log("Resuming game in Ball Phase");
    }
}