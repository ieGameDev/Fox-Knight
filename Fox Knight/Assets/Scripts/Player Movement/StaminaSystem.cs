using System;
using System.Collections;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField] private float _maxStamina = 90f;
    [SerializeField] private float _staminaRegenRate = 15f;
    [SerializeField] private float _staminaCostPerAttack = 35f;
    [SerializeField] private float _staminaCostPerJump = 20f;
    private float _currentStamina;

    private CharacterMovement _characterMovement;

    private bool _isStaminaBoostActive = false;
    public bool IsStaminaBoostActive
    {
        get { return _isStaminaBoostActive; }
    }

    private Coroutine _staminaBoostCoroutine;

    [SerializeField] private StaminaBar _staminaBar;

    public float MaxStamina
    {
        get { return _maxStamina; }
        private set { _maxStamina = value; }
    }

    public float CurrentStamina
    {
        get { return _currentStamina; }
        private set { _currentStamina = Mathf.Clamp(value, 0f, _maxStamina); }
    }

    public event Action<float> StaminaChanged;

    private void Start()
    {
        CurrentStamina = _maxStamina;
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if (CurrentStamina < _maxStamina)
        {
            CurrentStamina += _staminaRegenRate * Time.deltaTime;
            CurrentStamina = Mathf.Clamp(CurrentStamina, 0f, _maxStamina);
            StaminaChanged?.Invoke(CurrentStamina);
        }
    }

    public void StartStaminaBoost()
    {
        if (_staminaBoostCoroutine != null)
        {
            StopCoroutine(_staminaBoostCoroutine);
        }

        _staminaBoostCoroutine = StartCoroutine(EnableStaminaConservationForDuration(20f));
    }

    private IEnumerator EnableStaminaConservationForDuration(float duration)
    {
        _isStaminaBoostActive = true;
        _staminaBar.StaminaBoost();
        yield return new WaitForSeconds(duration);
        _isStaminaBoostActive = false;
    }

    public bool CanPerformAttack()
    {
        return CurrentStamina >= _staminaCostPerAttack;
    }

    public bool CanPerformJump()
    {
        return CurrentStamina >= _staminaCostPerJump;
    }

    public void PerformAttack()
    {
        if (!_isStaminaBoostActive && CanPerformAttack())
        {
            CurrentStamina -= _staminaCostPerAttack;
        }
        StartCoroutine(FinishAttack());
    }

    public void PeformJump()
    {
        if (!_isStaminaBoostActive && CanPerformJump())
        {
            CurrentStamina -= _staminaCostPerJump;
        }
    }

    private IEnumerator FinishAttack()
    {
        yield return new WaitForSeconds(0.2f);
        _characterMovement.AttackingIsEnd();
    }
}
