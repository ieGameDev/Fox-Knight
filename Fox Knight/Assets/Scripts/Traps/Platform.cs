using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    private Transform _platformTransform;
    private bool _movingTowardsMax = true;

    private void Start()
    {
        _platformTransform = transform;
    }

    private void LateUpdate()
    {
        Vector3 currentPosition = transform.position;

        float newPositionX = currentPosition.x + _speed * Time.deltaTime;

        if ((newPositionX >= _maxX && _movingTowardsMax) || (newPositionX <= _minX && !_movingTowardsMax))
        {
            _speed *= -1;
            _movingTowardsMax = !_movingTowardsMax;
        }

        transform.position = new Vector3(newPositionX, currentPosition.y, currentPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = _platformTransform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
