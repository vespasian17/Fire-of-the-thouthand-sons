/// <summary>
/// Интерфейс для объектов, которые могут получать урон.
/// </summary>
public interface IDamageable
{
    /// <summary>
    /// Метод для получения урона.
    /// </summary>
    /// <param name="damage">Количество полученного урона.</param>
    void TakeDamage(int damage);

    /// <summary>
    /// Метод для проверки состояния объекта.
    /// </summary>
    /// <returns>Возвращает true, если объект еще жив.</returns>
    bool IsAlive();
}