using UnityEngine;
using UnityEngine.EventSystems;
using static CharacterMovement;

public class AttackButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AttackHandler _attackHandler;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private StaminaSystem _stamina;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (CanAttack())
        {
            if (_stamina.CanPerformAttack() && !_characterMovement.IsAttackingInProgress)
            {
                _characterMovement.SwitchStateTo(CharacterState.Attacking);
                return;
            }
        }
    }

    private bool CanAttack()
    {
        return _characterController != null &&
            _characterMovement != null &&
            _characterController.isGrounded;
    }

    private void OnDisable()
    {
        if (_attackHandler != null)
        {
            _attackHandler.MouseButtonDown = false;
        }
    }
}
