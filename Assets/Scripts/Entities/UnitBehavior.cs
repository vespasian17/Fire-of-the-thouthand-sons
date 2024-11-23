using UnityEngine;

/// <summary>
/// Класс UnitBehavior отвечает за поведение игрового юнита и реализацию интерфейса IDamageable.
/// </summary>
public class UnitBehavior : MonoBehaviour, IDamageable
{
    [SerializeField] private UnitHealth _unitHealth;

    private void Awake()
    {
        if (_unitHealth == null)
        {
            _unitHealth = new UnitHealth(100, 100);
        }
    }

    /// <summary>
    /// Метод для получения урона.
    /// </summary>
    /// <param name="damage">Количество полученного урона.</param>
    public void TakeDamage(int damage)
    {
        _unitHealth.TakeDamage(damage);
        if (_unitHealth.Health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Метод для проверки состояния объекта.
    /// </summary>
    /// <returns>Возвращает true, если объект еще жив.</returns>
    public bool IsAlive()
    {
        return _unitHealth.Health > 0;
    }

    /// <summary>
    /// Метод, вызываемый при смерти юнита.
    /// </summary>
    private void Die()
    {
        // Логика смерти юнита (например, анимация смерти, удаление объекта и т.д.)
        Destroy(gameObject);
    }
}