using UnityEngine;


public class SceletonMovement : Enemy
{
    private bool _shouldAttack = false;
    private float _lookSpeed = 5f;

    public override void MoveEnemy()
    {
        if (_damageSystem != null && _damageSystem.CurrentHealth <= 0 || _targetPlayer == null || _enemyAnimator.IsTakingDamage == true)
        {
            _navMeshAgent.ResetPath();
            _enemyAnimator.Run(false);
            ShouldAttack(false);
            return;
        }

        float distanceToPlayer = Vector3.Distance(_targetPlayer.position, transform.position);
        bool isNearPlayer = distanceToPlayer <= _detectionDistance;

        if (isNearPlayer)
        {
            transform.LookAt(_targetPlayer);

            if (distanceToPlayer <= _navMeshAgent.stoppingDistance)
            {
                Quaternion playerLookRotation = Quaternion.LookRotation(transform.position - _targetPlayer.position);
                _targetPlayer.rotation = Quaternion.Slerp(_targetPlayer.rotation, playerLookRotation, Time.deltaTime * _lookSpeed);
            }

            if (distanceToPlayer >= _navMeshAgent.stoppingDistance)
            {
                _navMeshAgent.SetDestination(_targetPlayer.position);
                _enemyAnimator.Run(true);

                _shouldAttack = false;
            }
            else
            {
                _navMeshAgent.SetDestination(transform.position);
                _enemyAnimator.Run(false);

                _shouldAttack = true;
            }
        }
        else
        {
            _navMeshAgent.SetDestination(_initialPosition);

            ShouldAttack(false);

            _enemyAnimator.Run(Vector3.Distance(transform.position, _initialPosition) > _navMeshAgent.stoppingDistance);
        }

        ShouldAttack(_shouldAttack);
    }
}
