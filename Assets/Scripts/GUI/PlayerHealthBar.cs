using UnityEngine;

public class PlayerHealthBar : HealthBar
{
    protected override void OnHealthChanged(float valueAsPercentage)
    {
        _healthBarFilling.fillAmount = valueAsPercentage;
    }
}
