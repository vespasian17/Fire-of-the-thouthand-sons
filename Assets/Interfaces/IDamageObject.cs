/// <summary>
/// Интерфейс для всех объектов, наносящих урон.
/// </summary>

public interface IDamageObject
{
    /// <summary>
    /// Получает количество урона, наносимого объектом.
    /// </summary>
    /// <returns>Количество урона.</returns>
    public int GetDamageAmount();
}
