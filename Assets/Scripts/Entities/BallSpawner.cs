using System;
using Core;
using UnityEngine;

/// <summary>
/// Класс BallSpawner отвечает за создание и управление появлением шаров.
/// </summary>
public class BallSpawner : MonoBehaviour
{
    private Vector3 _spawnPosition;

    // ReSharper disable Unity.PerformanceAnalysis
    /// <summary>
    /// Создает шары в ряду.
    /// </summary>
    /// <param name="ballPrefab">Префаб шара.</param>
    /// <param name="wall">Логика стены из шаров.</param>
    public void SpawnBallsInARow(GameObject ballPrefab, WallOfBallLogic wall)
    {
        float ballDiameter = GetBallDiameter(FireWavesManager.Instance.SpaceBetweenBalls, FireWavesManager.Instance.NumberOfBalls); // Определяем диаметр шара

        _spawnPosition = GetFirstBallSpawnPoint(wall, ballDiameter); // Получаем точку появления первого шара
        Transform ballsContainer = Instantiate(wall.transform); // Создаем контейнер для шаров
        
        for (int i = 0; i < FireWavesManager.Instance.NumberOfBalls; i++) // Цикл создания шаров в ряду
        {
            GameObject createdBall = CreateBall(ballPrefab, ballsContainer, ballDiameter, wall); // Создаем и настраиваем шар
            _spawnPosition += (ballDiameter + FireWavesManager.Instance.SpaceBetweenBalls) * wall.GetSpawnDirectionOfWallBall(); // Обновляем позицию для следующего шара
        }
        
        // Уничтожаем заданное количество шаров
        wall.GetBallDestroyer().DestroyRandomBalls(
            FireWavesManager.Instance.DelayBetweenDestroyingBalls, 
            FireWavesManager.Instance.MoveDelay, 
            FireWavesManager.Instance.DestroyBallsCount, 
            wall.GetListOfBalls()
        );
    }

    /// <summary>
    /// Создает и настраивает шар.
    /// </summary>
    /// <param name="ballPrefab">Префаб шара.</param>
    /// <param name="container">Контейнер для шаров.</param>
    /// <param name="ballDiameter">Диаметр шара.</param>
    /// <param name="wall">Логика стены из шаров.</param>
    /// <returns>Созданный шар.</returns>
    private GameObject CreateBall(GameObject ballPrefab, Transform container, float ballDiameter, WallOfBallLogic wall)
    {
        GameObject createdBall = Instantiate(ballPrefab, container);
        createdBall.transform.position = _spawnPosition;
        Ball ballConfig = createdBall.GetComponent<Ball>();
        wall.AddBallToDestroyList(ballConfig);
        ballConfig.BallMoveDirection = wall.GetMoveDirection();
        ballConfig.SetBallSize(ballDiameter);
        return createdBall;
    }

    /// <summary>
    /// Определяет диаметр шара в зависимости от размера арены и количества шаров.
    /// </summary>
    /// <param name="spaceBetweenBalls">Расстояние между шарами.</param>
    /// <param name="numberOfBalls">Количество шаров.</param>
    /// <returns>Диаметр шара.</returns>
    private float GetBallDiameter(float spaceBetweenBalls, int numberOfBalls)
    {
        return (GameManager.ArenaSize - (spaceBetweenBalls * numberOfBalls - spaceBetweenBalls)) / numberOfBalls;
    }

    /// <summary>
    /// Возвращает первую точку появления шара с учетом смещений в зависимости от диаметра шара.
    /// </summary>
    /// <param name="wallOfBall">Логика стены из шаров.</param>
    /// <param name="ballDiameter">Диаметр шара.</param>
    /// <returns>Первая точка появления шара.</returns>
    private Vector3 GetFirstBallSpawnPoint(WallOfBallLogic wallOfBall, float ballDiameter)
    {
        Vector3 spawnPosition = wallOfBall.WallOfBallSpawnPoint;
        spawnPosition.y = ballDiameter / 2;
        if (wallOfBall.GetSpawnDirectionOfWallBall().x > 0f) spawnPosition.x += ballDiameter / 2;
        if (wallOfBall.GetSpawnDirectionOfWallBall().z > 0f) spawnPosition.z += ballDiameter / 2;
        return spawnPosition;
    }
}
