using UnityEngine;
using static CharacterMovement;

public class JoystickForMovement : JoystickHandler
{
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private PlayerAnimator _playerAnimator;
    private Vector3 _moveVector;


    private void Update()
    {
        if (_characterMovement == null)
        {
            return;
        }

        if (!_playerAnimator.IsDead && !_playerAnimator.IsTakingDamage)
        {
            switch (_characterMovement.CurrentState)
            {
                case CharacterState.Normal:
                    if (_inputVector.x != 0 || _inputVector.y != 0)
                    {
                        _characterMovement.MoveCharacter(new Vector3(_inputVector.x, 0, _inputVector.y));
                        _characterMovement.RotateCharacter(new Vector3(_inputVector.x, 0, _inputVector.y));
                    }
                    else
                    {
                        _moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                        _moveVector = Vector3.ClampMagnitude(_moveVector, 1f);

                        _characterMovement.MoveCharacter(_moveVector);
                        _characterMovement.RotateCharacter(_moveVector);
                    }
                    break;
                case CharacterState.Attacking:
                    break;
            }
        }
    }
}
