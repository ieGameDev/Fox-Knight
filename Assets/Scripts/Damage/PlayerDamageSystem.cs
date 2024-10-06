using UnityEngine;

public class PlayerDamageSystem : DamageSystem
{
    private PlayerAnimator _playerAnimator;

    [SerializeField] private SoundManager _soundManager;

    private string _playerDeadVFXPath = "PlayerDeath";
    private GameObject _playerDeadVFX;

    private CharacterMovement _characterMovement;

    private void Awake()
    {
        _playerDeadVFX = Resources.Load<GameObject>(_playerDeadVFXPath);
    }

    protected override void Start()
    {
        base.Start();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _characterMovement = GetComponent<CharacterMovement>();
    }
    private void Update()
    {
        if (transform.position.y < -1.5f)
        {
            PlayerDead();
        }
    }

    protected override void Dead()
    {
        _playerAnimator.Dead();
    }

    protected override void Damage()
    {
        _playerAnimator.Damage();
    }

    protected override void StopTakingDamage()
    {
        _playerAnimator.StopTakingDamage();
        _characterMovement.AttackingIsEnd();
    }

    public void PlayerDead()
    {
        Instantiate(_playerDeadVFX, transform.position, Quaternion.identity);
        _soundManager.PlayPlayerDeadSound();
        Destroy(gameObject);
    }
}
