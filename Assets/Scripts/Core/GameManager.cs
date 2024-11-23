using Core;
using UnityEngine;

/// <summary>
/// Класс GameManager отвечает за управление состоянием игры, настройкой камеры и взаимодействием с фазами боя.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraController _camera;

    /// <summary>
    /// Размер арены.
    /// </summary>
    public const float ArenaSize = 28.5f;

    public static GameManager Instance { get; private set; }

    public static FightPhase FightPhase { get; private set; }

    public UnitHealth PlayerHealth { get; private set; } = new UnitHealth(20000, 20000);

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        FightPhase = new FightPhase(new IdlePhaseState());
        FightPhase.Notify += ChangeState;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            FightPhase.Idle();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FightPhase.BallPhase();
        }
    }

    /// <summary>
    /// Метод для изменения состояния камеры в зависимости от фазы боя.
    /// </summary>
    /// <param name="state">Текущее состояние фазы боя.</param>
    private void ChangeState(State state)
    {
        switch (state)
        {
            case BallPhaseState:
                _camera.CameraZoomOut();
                FireWavesManager.Instance.BeginSpawnWallsOfBalls();
                break;
            case IdlePhaseState:
                _camera.CameraZoomIn();
                break;
        }
    }

    /// <summary>
    /// Проверяет, соответствует ли текущее состояние заданному типу.
    /// </summary>
    /// <typeparam name="TState">Тип состояния.</typeparam>
    /// <param name="state">Текущее состояние.</param>
    /// <returns>Возвращает true, если текущее состояние соответствует заданному типу.</returns>
    private static bool CheckPhaseState<TState>(State state)
    {
        return state is TState;
    }
}
