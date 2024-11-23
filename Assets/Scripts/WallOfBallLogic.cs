using System.Collections.Generic;
using UnityEngine;

public class WallOfBallLogic : MonoBehaviour
{
    [SerializeField] private Vector3 spawnDirection;
    [SerializeField] private Vector3 moveDirection;
    private List<Ball> _listOfBalls = new(); // Создается один список для всех волн шаров. Управление должно быть в другом месте.
    private BallsDestroyer _ballsDestroyer;

    public Vector3 WallOfBallSpawnPoint { get; private set; }

    private void Awake()
    {
        WallOfBallSpawnPoint = transform.position;
        
        if (!TryGetComponent(out _ballsDestroyer))
        {
            _ballsDestroyer = gameObject.AddComponent<BallsDestroyer>();
        }
    }

    /// <summary>
    /// Возвращает экземпляр BallsDestroyer.
    /// </summary>
    public BallsDestroyer GetBallDestroyer()
    {
        return _ballsDestroyer;
    }
    
    /// <summary>
    /// Возвращает список шаров.
    /// </summary>
    public List<Ball> GetListOfBalls()
    {
        return _listOfBalls;
    }
    
    /// <summary>
    /// Добавляет шар в список для уничтожения.
    /// </summary>
    public void AddBallToDestroyList(Ball ball)
    {
        _listOfBalls.Add(ball);
    }

    /// <summary>
    /// Возвращает направление спауна стен шаров.
    /// </summary>
    public Vector3 GetSpawnDirectionOfWallBall()
    {
        return spawnDirection;
    }
    
    /// <summary>
    /// Возвращает направление движения.
    /// </summary>
    public Vector3 GetMoveDirection()
    {
        return moveDirection;
    }
}