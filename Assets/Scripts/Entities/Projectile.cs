using UnityEngine;

/// <summary>
/// Класс Projectile отвечает за поведение снаряда, включая нанесение урона и пробивание целей.
/// </summary>
public class Projectile : MonoBehaviour, IDamageObject
{
    [SerializeField] private int _projectileMinDamage = 7122;
    [SerializeField] private int _projectileMaxDamage = 10683;
    [SerializeField] private float _projectileSpeed = 0;
    [SerializeField] private int _pierceCount = 1;

    public int ProjectileMinDamage
    {
        get => _projectileMinDamage;
        set => _projectileMinDamage = value;
    }

    public int ProjectileMaxDamage
    {
        get => _projectileMaxDamage;
        set => _projectileMaxDamage = value;
    }

    public float ProjectileSpeed
    {
        get => _projectileSpeed;
        set => _projectileSpeed = value;
    }

    public int PierceCount
    {
        get => _pierceCount;
        set => _pierceCount = value;
    }

    /// <summary>
    /// Конструктор для инициализации снаряда.
    /// </summary>
    public Projectile(int projectileMinDamage, int projectileMaxDamage, float projectileSpeed, int pierceCount)
    {
        _projectileMinDamage = projectileMinDamage;
        _projectileMaxDamage = projectileMaxDamage;
        _projectileSpeed = projectileSpeed;
        _pierceCount = pierceCount;
    }

    /// <summary>
    /// Пустой конструктор.
    /// </summary>
    public Projectile() { }

    /// <summary>
    /// Получает количество урона, наносимого снарядом.
    /// </summary>
    /// <returns>Количество урона.</returns>
    public int GetDamageAmount()
    {
        return UnityEngine.Random.Range(_projectileMinDamage, _projectileMaxDamage);
    }

    /// <summary>
    /// Обрабатывает пробивание цели снарядом.
    /// </summary>
    protected void TargetPierced()
    {
        if (_pierceCount >= 0) _pierceCount--;
        Debug.Log("I can pierce " + _pierceCount + " more targets");
        if (_pierceCount <= 0) Destroy(this.gameObject);
    }

    /// <summary>
    /// Обрабатывает столкновение с объектом, который может получать урон.
    /// </summary>
    /// <param name="damageableObject">Коллайдер объекта, с которым произошло столкновение.</param>
    protected virtual void OnTriggerEnter(Collider damageableObject)
    {
        var damageable = damageableObject.gameObject.GetComponent<IDamageable>();
        if (damageable == null)
        {
            Destroy(this.gameObject);
            return;
        }
        TargetPierced();
    }
}
