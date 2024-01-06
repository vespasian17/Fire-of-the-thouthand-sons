
public abstract class State
{
    protected FightPhase _context;

    public void SetContext(FightPhase context)
    {
        this._context = context;
    }

    public abstract void EndBallPhase();

    public abstract void StartBallPhase();
    
    public abstract void ResumeGame();
}
