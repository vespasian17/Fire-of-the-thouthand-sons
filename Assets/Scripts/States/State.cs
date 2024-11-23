/// <summary>
/// Абстрактный класс для реализации шаблона состояния (State Pattern).
/// </summary>
public abstract class State
{
    /// <summary>
    /// Контекстное состояние для текущей фазы боя.
    /// </summary>
    protected FightPhase _context;

    /// <summary>
    /// Устанавливает контекст для текущего состояния.
    /// </summary>
    /// <param name="context">Контекст фазы боя.</param>
    public void SetContext(FightPhase context)
    {
        this._context = context;
    }

    /// <summary>
    /// Заканчивает фазу с шарами.
    /// </summary>
    public abstract void EndBallPhase();

    /// <summary>
    /// Начинает фазу с шарами.
    /// </summary>
    public abstract void StartBallPhase();
    
    /// <summary>
    /// Возобновляет игру.
    /// </summary>
    public abstract void ResumeGame();
}