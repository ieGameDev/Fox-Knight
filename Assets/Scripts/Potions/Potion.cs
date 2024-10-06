using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    private float _rotationSpeed = 50f;
    private float _sinSpeed = 5f;
    private float _sinAmplitude = 0.2f;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);

        float floatOffset = Mathf.Sin(Time.time * _sinSpeed) * _sinAmplitude;
        transform.position = _startPosition + new Vector3(0, floatOffset, 0);
    }
}
