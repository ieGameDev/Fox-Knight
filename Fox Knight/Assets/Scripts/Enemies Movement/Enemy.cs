using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Movement Settings")]
    [SerializeField] private float _moveSpeed;
    [HideInInspector] public Vector3 velocityDirection;

    [Header("Enemy Components")]
    protected CharacterController _characterController;
    protected EnemyAnimator _enemyAnimator;
    protected EnemyDamageCaster _enemyDamageCaster;
    protected EnemyDamageSystem _damageSystem;

    [Header("AI Settings")]
    [SerializeField] protected float _detectionDistance;
    protected NavMeshAgent _navMeshAgent;
    protected Transform _targetPlayer;
    protected Vector3 _initialPosition;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemyAnimator = GetComponent<EnemyAnimator>();

        _damageSystem = GetComponent<EnemyDamageSystem>();
        _enemyDamageCaster = GetComponentInChildren<EnemyDamageCaster>();

        _targetPlayer = GameObject.FindWithTag("Player").transform;
        _navMeshAgent.speed = _moveSpeed;
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GravityHandling();
        MoveEnemy();
    }

    private void GravityHandling()
    {
        velocityDirection.y -= 9.8f * Time.deltaTime;
    }

    public abstract void MoveEnemy();

    public void ShouldAttack(bool shouldAttack)
    {
        _enemyAnimator.Attack(shouldAttack);
    }

    public void ApplyDamage(int damage)
    {
        if (_damageSystem != null)
        {
            _damageSystem.ApplyDamage(damage);
        }
    }

    public void EnemyEnableDamageCaster()
    {
        _enemyDamageCaster.EnableDamageCaster();
        StartCoroutine(EnemyDisableDamageCaster(0.3f));
    }

   
    private IEnumerator EnemyDisableDamageCaster(float delay)
    {
        yield return new WaitForSeconds(delay);
        _enemyDamageCaster.DisableDamageCaster();
    }
}
