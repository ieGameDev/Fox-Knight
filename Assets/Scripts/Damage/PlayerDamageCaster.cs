using UnityEngine;

public class PlayerDamageCaster : DamageCaster
{
    private PlayerVFXManager _playerVFXManager;

    protected override void Start()
    {
        base.Start();
        _playerVFXManager = transform.parent.GetComponent<PlayerVFXManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_targetTag) && !_damagedTargetList.Contains(other))
        {
            Enemy target = other.GetComponent<Enemy>();
            EnemyDamageText enemyDamageText = other.GetComponent<EnemyDamageText>();

            if (target != null)
            {
                int damageAmount = Random.Range(_minDamage, _maxDamage);
                target.ApplyDamage(damageAmount);

                if (enemyDamageText != null)
                {
                    enemyDamageText.DisplayDamage(damageAmount);
                }

                if (_playerVFXManager != null)
                {
                    Vector3 originalPosition = transform.position - transform.forward * _damageCasterCollider.bounds.extents.z;
                    RaycastHit hit;

                    if (Physics.BoxCast(originalPosition, _damageCasterCollider.bounds.extents / 2, transform.forward, out hit, transform.rotation, _damageCasterCollider.bounds.extents.z, 1 << 6))
                    {
                        _playerVFXManager.PlaySwordHit(hit.point + Vector3.up * 0.2f);
                    }
                }
            }
            _damagedTargetList.Add(other);
        }
    }
}
