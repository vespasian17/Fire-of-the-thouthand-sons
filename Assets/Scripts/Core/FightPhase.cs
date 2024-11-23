using UnityEngine;

/// <summary>
/// Класс FightPhase управляет переходами между состояниями в фазе боя.
/// </summary>
public class FightPhase
{
    private State _state = null;
    public delegate void FightPhaseHandler(State state);
    public event FightPhaseHandler Notify;

    /// <summary>
    /// Конструктор инициализирует начальное состояние.
    /// </summary>
    /// <param name="state">Начальное состояние.</param>
    public FightPhase(State state)
    {
        this.TransitionTo(state);
    }

    /// <summary>
    /// Переход к новому состоянию.
    /// </summary>
    /// <param name="state">Новое состояние.</param>
    public void TransitionTo(State state)
    {
        if (state == null)
        {
            Debug.LogError("TransitionTo method received a null state.");
            return;
        }

        Debug.Log($"Context: Transition to {state.GetType().Name}.");
        this._state = state;
        this._state.SetContext(this);
        Notify?.Invoke(_state);
    }

    /// <summary>
    /// Завершение фазы с шарами.
    /// </summary>
    public void Idle()
    {
        this._state.EndBallPhase();
    }

    /// <summary>
    /// Начало фазы с шарами.
    /// </summary>
    public void BallPhase()
    {
        this._state.StartBallPhase();
    }

    /// <summary>
    /// Пауза в фазе боя.
    /// </summary>
    public void Pause()
    {
        this._state.ResumeGame();
    }

    /// <summary>
    /// Получение текущего состояния.
    /// </summary>
    /// <returns>Текущее состояние.</returns>
    public State GetCurrentState() => _state;
}