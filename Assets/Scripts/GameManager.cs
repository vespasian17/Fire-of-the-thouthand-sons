using System;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraController _camera;
    [SerializeField] private BallsManager ballsManager;
    public static GameManager gameManager { get; private set; }

    public static FightPhase FightPhase { get; private set; }

    public UnitHealth _playerHealth = new UnitHealth(20000, 20000);
    void Awake()
    {
        // --------------------------------------------------------------------------------------------------------------//
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
        // --------------------------------------------------------------------------------------------------------------//
        
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


    private void ChangeState(State state)
    {
        switch (state)
        {
            case BallPhaseState:
                _camera.CameraZoomOut();
                ballsManager.BeginSpawnWallsOfBalls();
                break;
            case IdlePhaseState:
                _camera.CameraZoomIn();
                break;
        }
    }

    private static bool CheckPhaseState<TState>(State state)                   // Check fight phase state method
    {
        Type type = typeof(TState);

        if (type == state.GetType())
        {
            return true;
        }
        return false;
    }
}
