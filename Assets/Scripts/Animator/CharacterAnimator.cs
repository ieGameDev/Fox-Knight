using UnityEngine;

public abstract class CharacterAnimator : MonoBehaviour
{
    [Header("Animation Components")]
    [SerializeField] protected Animator _animator;

    protected bool _isDead = false;
    protected bool _isTakeDamage = false;

    public bool IsDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }

    public bool IsTakingDamage
    {
        get { return _isTakeDamage; }
        set { _isTakeDamage = value; }
    }
    
    public virtual void Damage()
    {
        if (!_isDead && !_isTakeDamage && _animator != null)
        {
            _animator.SetTrigger("TakeDamage");
            _isTakeDamage = true;
        }
    }

    public virtual void StopTakingDamage()
    {
        if (_animator != null)
        {
            _animator.SetTrigger("StopTakingDamage");
            _isTakeDamage = false;
        }
    }

    public virtual void Dead()
    {
        if (!_isDead && _animator != null)
        {
            _animator.SetTrigger("Dead");
            _isDead = true;
        }
    }
}
