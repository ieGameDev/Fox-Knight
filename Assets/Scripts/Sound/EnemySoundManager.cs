using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemySoundManager : MonoBehaviour
{
    [SerializeField] private BlockButton _blockButton;
    [SerializeField] private BlockHandler _blockHandler;

    private AudioSource _audioSource;

    [Header("Damage Sounds")]
    [SerializeField] private AudioClip[] _damageSounds;

    [Header("Sword Sounds")]
    [SerializeField] private AudioClip[] _swordSounds;

    [Header("Steps Sounds")]
    [SerializeField] private AudioClip[] _footsteps;

    [Header("Player Shield Sound")]
    [SerializeField] private AudioClip _shield;

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

    public void PLayDamageSound()
    {
        AudioClip randomDamageSound = _damageSounds[Random.Range(0, _damageSounds.Length)];
        _audioSource.PlayOneShot(randomDamageSound);
    }

    public void PlayFootstepsSound()
    {
        AudioClip randomStepsSound = _footsteps[Random.Range(0, _footsteps.Length)];
        _audioSource.PlayOneShot(randomStepsSound);
    }

    public void PlayShieldSound()
    {
        if (_blockButton != null && _blockButton.IsTouchBlocking || _blockHandler != null && _blockHandler.RightMouseButtonPressed)
        {
            if (Time.timeScale == 1)
                _audioSource.PlayOneShot(_shield);
        }
    }
}
