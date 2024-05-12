using UnityEngine;

public class PlayerAnimator : CharacterAnimator
{
    public void Run(Vector3 moveDirection)
    {
        if (!_isDead && !_isTakeDamage && _animator != null)
        {
            bool isMoving = moveDirection.x != 0 || moveDirection.z != 0;
            _animator.SetBool("Run", isMoving);
        }
    }

    public void Jump(bool isGround)
    {
        if (!_isDead && !_isTakeDamage && _animator != null)
        {
            _animator.SetBool("Jump", isGround);
        }
    }

    public void Attack()
    {
        if (!_isDead && !_isTakeDamage && _animator != null)
        {
            _animator.SetTrigger("Attack");
        }
    }

    public void Block(bool IsBlocking)
    {
        if (!_isDead && !_isTakeDamage && _animator != null)
        {
            _animator.SetBool("IsBlocking", IsBlocking);
        }
    }

    public bool IsAnimationPlaying(string animationName)
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        bool isPlaying = stateInfo.IsName(animationName);
        bool isPlayingAndNotFinished = stateInfo.normalizedTime < 1f && stateInfo.normalizedTime > 0f;
        return isPlaying && isPlayingAndNotFinished;
    }
}
