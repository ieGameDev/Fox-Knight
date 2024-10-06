using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected DamageSystem _damageSystem;
    [SerializeField] protected Image _healthBarFilling;
    [SerializeField] protected Gradient _gradient;

    protected Camera _camera;

    protected void Awake()
    {
        _damageSystem.HealthChanged += OnHealthChanged;
        _camera = Camera.main;
    }

    protected void OnDestroy()
    {
        _damageSystem.HealthChanged -= OnHealthChanged;
    }

    protected virtual void OnHealthChanged(float valueAsPercentage)
    {
        _healthBarFilling.fillAmount = valueAsPercentage;
        _healthBarFilling.color = _gradient.Evaluate(valueAsPercentage);
    }
}
