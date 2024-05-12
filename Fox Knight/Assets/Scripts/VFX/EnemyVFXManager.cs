using UnityEngine;

public class EnemyVFXManager : MonoBehaviour
{
    private string _deadVFXPath = "EnemyDeathSkull";
    private GameObject _deadVFX;

    private void Awake()
    {
        _deadVFX = Resources.Load<GameObject>(_deadVFXPath);
    }

    public void EnemyDeadVFX()
    {
        Instantiate(_deadVFX, transform.position, Quaternion.identity);
    }
}
