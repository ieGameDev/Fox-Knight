using System.Collections.Generic;
using UnityEngine;

public abstract class DamageCaster : MonoBehaviour
{
    protected Collider _damageCasterCollider;
    protected List<Collider> _damagedTargetList;

    [SerializeField] protected int _minDamage = 25;
    [SerializeField] protected int _maxDamage = 35;

    [SerializeField] protected string _targetTag;

    protected virtual void Start()
    {
        _damageCasterCollider = GetComponent<Collider>();
        _damageCasterCollider.enabled = false;
        _damagedTargetList = new List<Collider>();
    }

    public void EnableDamageCaster()
    {
        _damagedTargetList.Clear();
        _damageCasterCollider.enabled = true;
    }

    public void DisableDamageCaster()
    {
        _damagedTargetList.Clear();
        _damageCasterCollider.enabled = false;
    }
}
