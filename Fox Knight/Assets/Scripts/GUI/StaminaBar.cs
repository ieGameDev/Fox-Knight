using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private StaminaSystem _stamina;
    [SerializeField] private Image _staminaBarFilling;
    [SerializeField] protected Gradient _gradient;

    [SerializeField] private Color _color;

    private void Awake()
    {
        _stamina.StaminaChanged += OnStaminaChanged;
    }

    private void OnDestroy()
    {
        _stamina.StaminaChanged -= OnStaminaChanged;
    }

    private void OnStaminaChanged(float currentStamina)
    {
        float fillAmount = currentStamina / _stamina.MaxStamina;

        _staminaBarFilling.fillAmount = fillAmount;

        if (_stamina.IsStaminaBoostActive)
        {
            _staminaBarFilling.color = _color;
        }
        else
        {
            _staminaBarFilling.color = _gradient.Evaluate(fillAmount);
        }
    }

    public void StaminaBoost()
    {
        _staminaBarFilling.color = _color;
    }
}
