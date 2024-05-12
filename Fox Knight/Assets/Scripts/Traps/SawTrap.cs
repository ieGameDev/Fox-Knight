using UnityEngine;

public enum SawAxis
{
    X,
    Z
}

public class SawTrap : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private float _speed;
    [SerializeField] private float _minPosition;
    [SerializeField] private float _maxPosition;

    [SerializeField] private SawAxis _moveAxis = SawAxis.X;

    private bool _movingTowardsMax = true;

    private int _damage = 30;

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

    private void LateUpdate()
    {
        Vector3 currentPosition = transform.position;

        float newPosition;
        if (_moveAxis == SawAxis.X)
            newPosition = currentPosition.x + _speed * Time.deltaTime;
        else
            newPosition = currentPosition.z + _speed * Time.deltaTime;

        if ((newPosition >= _maxPosition && _movingTowardsMax) || (newPosition <= _minPosition && !_movingTowardsMax))
        {
            _speed *= -1;
            _movingTowardsMax = !_movingTowardsMax;
        }

        if (_moveAxis == SawAxis.X)
            transform.position = new Vector3(newPosition, currentPosition.y, currentPosition.z);
        else
            transform.position = new Vector3(currentPosition.x, currentPosition.y, newPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CharacterMovement target = other.GetComponent<CharacterMovement>();

            if (target != null)
            {
                target.ApplyDamage(_damage, true);
            }
        }
    }
}
