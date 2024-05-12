using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSoundManager : MonoBehaviour
{
    private AudioSource _audioSource;

    [Header("Damage Sounds")]
    [SerializeField] private AudioClip _damageSound;

    [Header("Sword Sounds")]
    [SerializeField] private AudioClip[] _swordSounds;

    [Header("Steps Sounds")]
    [SerializeField] private AudioClip[] _footsteps;

    [Header("Jump Sound")]
    [SerializeField] private AudioClip _jump;

    [Header("Key Sounds")]
    [SerializeField] private AudioClip _ring;

    [Header("Get Key Sound")]
    [SerializeField] private AudioClip _getKey;

    [Header("Health Sounds")]
    [SerializeField] private AudioClip _aid;
    [SerializeField] private AudioClip _fullHealth;

    [Header("Stamina Boost")]
    [SerializeField] private AudioClip _staminaBoost;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Pause();
            }
        }
        else if (Time.timeScale == 1)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.UnPause();
            }
        }
    }

    public void PLaySwordSound()
    {
        AudioClip randomSwordSound = _swordSounds[Random.Range(0, _swordSounds.Length)];
        _audioSource.PlayOneShot(randomSwordSound);
    }

    public void PlayFootstepsSound()
    {
        AudioClip randomStepsSound = _footsteps[Random.Range(0, _footsteps.Length)];
        _audioSource.PlayOneShot(randomStepsSound);
    }

    public void PLayDamageSound()
    {
        if (Time.timeScale == 1)
            _audioSource.PlayOneShot(_damageSound);
    }

    public void PlayJumpSound()
    {
        if (Time.timeScale == 1)
            _audioSource.PlayOneShot(_jump);
    }

    public void PlayRingSound()
    {
        if (Time.timeScale == 1)
            _audioSource.PlayOneShot(_ring);
    }

    public void PlayKeySound()
    {
        if (Time.timeScale == 1)
            _audioSource.PlayOneShot(_getKey);
    }

    public void PlayAidSound()
    {
        if (Time.timeScale == 1)
            _audioSource.PlayOneShot(_aid);
    }

    public void PlayFullHealthSound()
    {
        if (Time.timeScale == 1)
            _audioSource.PlayOneShot(_fullHealth);
    }

    public void PlayStaminaBoostSound()
    {
        if (Time.timeScale == 1)
            _audioSource.PlayOneShot(_staminaBoost);
    }
}
