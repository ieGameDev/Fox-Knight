using UnityEngine;
using UnityEngine.EventSystems;
using static CharacterMovement;

public class BlockButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private BlockHandler _blockHandler;
    public bool IsTouchBlocking { get; set; }

    private void Update()
    {
        if (IsTouchBlocking)
        {
            _characterMovement.SwitchStateTo(CharacterState.Blocking);
            return;
        }
        else
        {
            _characterMovement.SwitchStateTo(CharacterState.Normal);
            return;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_characterController != null && _characterMovement != null)
        {
            if (_characterController.isGrounded)
            {
                IsTouchBlocking = true;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsTouchBlocking = false;
    }

    private void OnDisable()
    {
        if (_blockHandler != null)
        {
            _blockHandler.RightMouseButtonPressed = false;
        }
    }
}
