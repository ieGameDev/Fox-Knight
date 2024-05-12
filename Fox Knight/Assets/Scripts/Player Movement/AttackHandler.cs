using UnityEngine;
using static CharacterMovement;

public class AttackHandler : MonoBehaviour
{
    private CharacterMovement _characterMovement;
    private CharacterController _characterController;
    private StaminaSystem _stamina;
    public bool MouseButtonDown { get; set; }

    private void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _characterController = GetComponent<CharacterController>();
        _stamina = GetComponent<StaminaSystem>();
    }


    private void Update()
    {
        if (!_characterMovement.IsAttackingInProgress && Time.timeScale != 0)
        {
            MouseButtonDown = Input.GetMouseButtonDown(0);
        }

        Attack();
    }

    private void Attack()
    {
        if (MouseButtonDown && CanAttack() && !_characterMovement.IsAttackingInProgress)
        {
            if (_stamina.CanPerformAttack())
            {
                _characterMovement.SwitchStateTo(CharacterState.Attacking);
            }
        }
    }

    private bool CanAttack()
    {
        return _characterMovement != null &&
               _characterController != null &&
               _characterController.isGrounded;
    }

    private void OnDisable()
    {
        MouseButtonDown = false;
    }    
}
