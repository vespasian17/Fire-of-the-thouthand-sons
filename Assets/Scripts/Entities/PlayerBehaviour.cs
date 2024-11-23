using UnityEngine;

/// <summary>
/// Класс PlayerBehaviour отвечает за поведение игрока и взаимодействие с системой здоровья.
/// </summary>
public class PlayerBehaviour : UnitBehavior
{
    [SerializeField] private HealthBar _healthBar;

    private UnitHealth _unitHealth;

    private void Start()
    {
        if (_healthBar == null)
        {
            Debug.LogError("HealthBar component is missing.");
        }

        _unitHealth = GameManager.Instance.PlayerHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Heal(15);
        }
    }

    private new void TakeDamage(int damage)
    {
        if (_unitHealth != null)
        {
            _unitHealth.TakeDamage(damage);
            _healthBar?.SetHealth(_unitHealth.Health);
        }
    }

    private void Heal(int amount)
    {
        if (_unitHealth != null)
        {
            _unitHealth.TakeHeal(amount);
            _healthBar?.SetHealth(_unitHealth.Health);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageObject = other.gameObject.GetComponent<IDamageObject>();
        if (damageObject == null) return;

        Debug.Log("I touched a Damageable object");
        TakeDamage(damageObject.GetDamageAmount());
        Debug.Log("I took " + damageObject.GetDamageAmount() + " damage");
        //some effects
        //some particles
    }
}