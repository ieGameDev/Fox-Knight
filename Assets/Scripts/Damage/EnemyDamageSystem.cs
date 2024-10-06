using System;
using UnityEngine;

public class EnemyDamageSystem : DamageSystem
{
    private EnemyAnimator _enemyAnimator;
    private EnemyVFXManager _enemyVFXManager;

    [SerializeField] private SoundManager _soundManager;
    private SceletonCollection _sceletonCollection;

    public static event Action<GameObject> EnemyDied;

    protected override void Start()
    {
        base.Start();
        _enemyAnimator = GetComponent<EnemyAnimator>();
        _enemyVFXManager = GetComponent<EnemyVFXManager>();
        _sceletonCollection = GetComponentInParent<SceletonCollection>();
    }

    protected override void Dead()
    {        
        _enemyAnimator.Dead();
        OnEnemyDied();
    }

    private void OnEnemyDied()
    {
        if (EnemyDied != null)
        {
            EnemyDied(gameObject);
        }
    }

    protected override void Damage()
    {
        _enemyAnimator.Damage();
    }

    protected override void StopTakingDamage()
    {
        _enemyAnimator.StopTakingDamage();
    }

    public void EnemyDead()
    {
        Destroy(gameObject);
        _sceletonCollection.AddOne();
        _enemyVFXManager.EnemyDeadVFX();
        _soundManager.PlayEnemyDeadSound();
    }
}
