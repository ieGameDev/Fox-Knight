using System.Collections;
using UnityEngine;

public class CollapsingFloor : MonoBehaviour
{
    private float _rotationAngle = 90f;
    private float _rotationTime = 0.3f;
    private float _shakeDuration = 0.4f;
    private float _shakeMagnitude = 0.1f;

    private bool _isRotating = false;

    private TrapsSound _trapsSound;

    [SerializeField] private AudioClip _creakingSound;
    [SerializeField] private AudioClip _machanismSound;

    private void Start()
    {
        _trapsSound = GetComponent<TrapsSound>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isRotating)
        {
            _isRotating = true;
            StartCoroutine(ShakeAndRotateFloor());
        }
    }

    private IEnumerator ShakeAndRotateFloor()
    {
        Vector3 originalLocalPosition = transform.localPosition;
        Quaternion originalLocalRotation = transform.localRotation;

        float elapsedTime = 0f;

        _trapsSound.PlayMechanismSound(_machanismSound);

        while (elapsedTime < _shakeDuration)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * _shakeMagnitude;
            shakeOffset.z = 0;
            transform.localPosition = originalLocalPosition + shakeOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalLocalPosition;

        Quaternion startRotation = transform.localRotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(_rotationAngle, 0, 0);

        elapsedTime = 0f;

        _trapsSound.PlayCreakingSound(_creakingSound);

        while (elapsedTime < _rotationTime)
        {
            transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, (elapsedTime / _rotationTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //transform.localRotation = originalLocalRotation;
        _isRotating = false;
    }
}
