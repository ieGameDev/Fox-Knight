using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TrapsSound : MonoBehaviour
{
    private AudioSource _audioSource;

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

    public void PlayMechanismSound(AudioClip machanismSound)
    {
        if (Time.timeScale == 1)
            _audioSource.PlayOneShot(machanismSound);
    }

    public void PlayCreakingSound(AudioClip creakingSound)
    {
        if (Time.timeScale == 1)
            _audioSource.PlayOneShot(creakingSound);
    }
}
