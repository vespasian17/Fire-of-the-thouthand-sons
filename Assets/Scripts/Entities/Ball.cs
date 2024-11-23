using System;
using Core;
using UnityEngine;

/// <summary>
/// Класс Ball отвечает за поведение шара в игре.
/// </summary>
public class Ball : Projectile
{
    private float _initializationTime;

    /// <summary>
    /// Направление движения шара.
    /// </summary>
    public Vector3 BallMoveDirection { get; set; }

    private void Start()
    {
        _initializationTime = Time.time;
        ProjectileSpeed = FireWavesManager.Instance.WallOfBallSpeed;
    }

    private void Update()
    {
        if (Time.time - _initializationTime >= FireWavesManager.Instance.MoveDelay)
        {
            MoveInDirection(BallMoveDirection, ProjectileSpeed);
            RotateBall(100f);
        }
    }

    /// <summary>
    /// Устанавливает размер шара.
    /// </summary>
    /// <param name="ballRadius">Радиус шара.</param>
    public void SetBallSize(float ballRadius)
    {
        transform.localScale *= ballRadius;
    }

    /// <summary>
    /// Двигает шар в заданном направлении с заданной скоростью.
    /// </summary>
    /// <param name="movementDirection">Направление движения.</param>
    /// <param name="speed">Скорость движения.</param>
    private void MoveInDirection(Vector3 movementDirection, float speed)
    {
        transform.position += movementDirection * (speed * Time.deltaTime);
    }

    /// <summary>
    /// Вращает шар с заданной скоростью.
    /// </summary>
    /// <param name="rotationSpeed">Скорость вращения.</param>
    private void RotateBall(float rotationSpeed)
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}