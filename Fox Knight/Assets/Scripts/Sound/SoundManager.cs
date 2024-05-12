using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _playerDead;
    [SerializeField] private AudioClip _enemyDead;
    [SerializeField] private AudioClip _start;
    [SerializeField] private AudioClip _finish;
    [SerializeField] private AudioClip _wind;

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

    public void PlayPlayerDeadSound()
    {
        if (Time.timeScale == 1)
            _audioSource?.PlayOneShot(_playerDead);
    }

    public void PlayEnemyDeadSound()
    {
        if (Time.timeScale == 1)
            _audioSource?.PlayOneShot(_enemyDead);
    }

    public void PlayFinishSound()
    {
        if (Time.timeScale == 1)
            _audioSource?.PlayOneShot(_finish);
    }

    public void PlayWindSound()
    {
        if (Time.timeScale == 1)
            _audioSource?.PlayOneShot(_wind);
    }

    public void PlayStartSounds()
    {
        if (Time.timeScale == 1)
            _audioSource?.PlayOneShot(_start);
    }
}
