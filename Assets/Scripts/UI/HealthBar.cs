using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс HealthBar отвечает за отображение полоски здоровья.
/// </summary>
public class HealthBar : MonoBehaviour
{
    private Slider _healthSlider;

    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
        if (_healthSlider == null)
        {
            Debug.LogError("Slider component is missing on the GameObject.");
        }
    }

    /// <summary>
    /// Устанавливает максимальное значение здоровья.
    /// </summary>
    /// <param name="maxHealth">Максимальное значение здоровья.</param>
    public void SetMaxHealth(int maxHealth)
    {
        if (_healthSlider != null)
        {
            _healthSlider.maxValue = maxHealth;
            _healthSlider.value = maxHealth;
        }
    }

    /// <summary>
    /// Устанавливает текущее значение здоровья.
    /// </summary>
    /// <param name="health">Текущее значение здоровья.</param>
    public void SetHealth(int health)
    {
        if (_healthSlider != null)
        {
            _healthSlider.value = health;
        }
    }
}