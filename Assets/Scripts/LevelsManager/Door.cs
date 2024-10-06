using UnityEngine;

public class Door : MonoBehaviour
{
    private int _openSpeed = 75;

    [SerializeField] private KeySpawner _keySpawner;

    private DoorSound _doorSound;
    private bool _doorOpen = false;

    private void Start()
    {
        _doorSound = GetComponent<DoorSound>();
    }

    private void Update()
    {
        if (_keySpawner != null && _keySpawner.HaveKey)
        {
            if (!_doorOpen)
            {
                _doorSound.PlayDoorSound();
                _doorOpen = true;
            }
            DoorRotation();
        }
    }

    private void DoorRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, -130f, 0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _openSpeed * Time.deltaTime);
    }
}
