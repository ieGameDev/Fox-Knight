using UnityEngine;

public class StaminaBoost : Potion
{
    [SerializeField] private StaminaSystem _staminaSystem;
    [SerializeField] private PlayerSoundManager _playerSoundManager;

    private string _staminaBoostVFXPath = "StaminaBoost";
    private GameObject _staminaBoostVFX;

    private void Awake()
    {
        _staminaBoostVFX = Resources.Load<GameObject>(_staminaBoostVFXPath);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _staminaSystem.StartStaminaBoost();        
            Instantiate(_staminaBoostVFX, transform.position, Quaternion.identity);
            _playerSoundManager.PlayStaminaBoostSound();
            Destroy(gameObject);
        }
    }
}
