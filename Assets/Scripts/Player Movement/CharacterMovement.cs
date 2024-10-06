using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Character Movement Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [HideInInspector] public Vector3 velocityDirection;
    private bool _isBlocking = false;

    public bool IsAttackingInProgress { get; set; } = false;

    [Header("Character components")]
    private CharacterController _characterController;
    private GravityManager _gravityManager;
    private PlayerAnimator _playerAnimator;
    private AttackHandler _attackHandler;
    private PlayerDamageSystem _playerDamageSystem;
    private PlayerDamageCaster _damageCaster;

    public enum CharacterState
    {
        Normal, Attacking, Blocking
    }
    public CharacterState CurrentState;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _gravityManager = GetComponent<GravityManager>();
        _attackHandler = GetComponent<AttackHandler>();
        _playerDamageSystem = GetComponent<PlayerDamageSystem>();
        _damageCaster = GetComponentInChildren<PlayerDamageCaster>();
    }

    private void Update()
    {
        _gravityManager.GravityHandling();
        _playerAnimator.Block(_isBlocking);
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        velocityDirection.x = moveDirection.x * _moveSpeed;
        velocityDirection.z = moveDirection.z * _moveSpeed;
        _characterController.Move(velocityDirection * Time.deltaTime);

        _playerAnimator.Run(moveDirection);
    }

    public void RotateCharacter(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void ApplyDamage(int damage, bool ignoreBlocking = false)
    {
        if (_playerDamageSystem != null)
        {
            if (_isBlocking && !ignoreBlocking)
                _playerDamageSystem.ApplyDamage(0);
            else
                _playerDamageSystem.ApplyDamage(damage);
        }
    }

    public void SwitchStateTo(CharacterState newState)
    {
        _attackHandler.MouseButtonDown = false;

        switch (CurrentState)
        {
            case CharacterState.Normal:
                break;
            case CharacterState.Attacking:
                break;
            case CharacterState.Blocking:
                break;
        }

        switch (newState)
        {
            case CharacterState.Normal:
                _isBlocking = false;
                break;
            case CharacterState.Attacking:
                _isBlocking = false;
                _moveSpeed = 0;
                _playerAnimator.Attack();
                IsAttackingInProgress = true;
                StartCoroutine(AttackAnimationEnds(0.3f));
                break;
            case CharacterState.Blocking:
                IsAttackingInProgress = false;
                _isBlocking = true;
                break;
        }

        CurrentState = newState;
    }

    public void EnableDamageCaster()
    {
        _damageCaster.EnableDamageCaster();
        StartCoroutine(DisableDamageCaster(0.3f));
    }

    private IEnumerator DisableDamageCaster(float delay)
    {
        yield return new WaitForSeconds(delay);
        _damageCaster.DisableDamageCaster();
    }

    public void AttackingIsEnd()
    {
        IsAttackingInProgress = false;
    }

    private IEnumerator AttackAnimationEnds(float delay)
    {
        yield return new WaitForSeconds(delay);
        _moveSpeed = 7;
        SwitchStateTo(CharacterState.Normal);
    }
}
