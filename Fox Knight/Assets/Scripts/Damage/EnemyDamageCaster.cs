using UnityEngine;

public class EnemyDamageCaster : DamageCaster
{
    protected override void Start()
    {
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _targetTag && !_damagedTargetList.Contains(other))
        {
            CharacterMovement target = other.GetComponent<CharacterMovement>();

            if (target != null)
            {
                target.ApplyDamage(Random.Range(_minDamage, _maxDamage));
            }

            _damagedTargetList.Add(other);
        }
    }
}
