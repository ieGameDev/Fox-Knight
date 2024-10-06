using UnityEngine;

public class EnemyAnimator : CharacterAnimator
{
    public void Run(bool isMoving)
    {
        if (!_isDead && !_isTakeDamage && _animator != null)
        {
            _animator.SetBool("Run", isMoving);
        }
    }

    public void Attack(bool shouldAttack)
    {
        if (!_isDead && !_isTakeDamage && _animator != null)
        {
            _animator.SetBool("ShouldAttack", shouldAttack);
        }
    }
}
