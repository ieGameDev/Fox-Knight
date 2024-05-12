using UnityEngine;
using UnityEngine.UI;

public class KeySpawner : MonoBehaviour
{
    public bool HaveKey { get; private set; } = false;

    [SerializeField] private GameObject _keyPrefab;
    private PlayerSoundManager _playerSoundManager;
    private bool _keySpawned = false;
    private GameObject _selectedEnemy;

    [SerializeField] private Image _key;

    private void Start()
    {
        _playerSoundManager = GetComponent<PlayerSoundManager>();

        _key.gameObject.SetActive(false);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            int randomIndex = Random.Range(0, enemies.Length);
            _selectedEnemy = enemies[randomIndex];
        }
    }

    private void OnEnable()
    {
        EnemyDamageSystem.EnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        EnemyDamageSystem.EnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied(GameObject enemy)
    {
        if (!_keySpawned && enemy == _selectedEnemy)
        {
            Instantiate(_keyPrefab, enemy.transform.position, enemy.transform.rotation);
            _playerSoundManager.PlayKeySound();
            _keySpawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            _playerSoundManager.PlayRingSound();
            HaveKey = true;
            _key.gameObject.SetActive(true);
        }
    }
}
