using UnityEngine;

public class WaterSound : MonoBehaviour
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
}
