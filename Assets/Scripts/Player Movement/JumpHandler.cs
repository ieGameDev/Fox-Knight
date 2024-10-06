using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpTime;
    private float _startJumpVelocity;

    [Header("Character Components")]
    private CharacterController _characterController;
    private CharacterMovement _characterMovement;
    private GravityManager _gravityManager;
    private PlayerAnimator _playerAnimator;
    private PlayerSoundManager _soundManager;

    private StaminaSystem _stamina;


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _characterMovement = GetComponent<CharacterMovement>();
        _gravityManager = GetComponent<GravityManager>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _soundManager = GetComponent<PlayerSoundManager>();

        _stamina = GetComponent<StaminaSystem>();

        float maxHeightTime = _jumpTime / 2;
        _gravityManager.GravityForce = (2 * _jumpHeight) / Mathf.Pow(maxHeightTime, 2);
        _startJumpVelocity = (2 * _jumpHeight) / maxHeightTime;
    }

    private void Update()
    {
        _playerAnimator.Jump(!_characterController.isGrounded);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleJump();
        }
    }

    public void HandleJump()
    {
        if (CanJump())
        {
            if (_stamina.CanPerformJump())
            {
                _characterMovement.velocityDirection.y = _startJumpVelocity;
                _soundManager.PlayJumpSound();
            }
        }
    }

    private bool CanJump()
    {
        return _characterController != null &&
            _characterController != null &&
            _characterController.isGrounded;
    }
}
