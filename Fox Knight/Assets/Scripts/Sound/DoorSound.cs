using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorSound : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _doorSound;

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

    public void PlayDoorSound()
    {
        if (Time.timeScale == 1)
            _audioSource.PlayOneShot(_doorSound);
    }
}
