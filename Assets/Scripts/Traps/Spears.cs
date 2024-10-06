using System.Collections;
using UnityEngine;

public enum StartPoint
{
    LowerPosition,
    UpperPosition
}

public class Spears : MonoBehaviour
{
    private float _upperPosition = -1.1f;
    private float _lowerPosition = -1.7f;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private StartPoint _startPoint;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _spearsSound;

    private int _damage = 30;

    private bool _movingUp = true;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _movingUp = (_startPoint == StartPoint.LowerPosition);
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        while (true)
        {
            float startPos = _movingUp ? _lowerPosition : _upperPosition;
            float targetPos = _movingUp ? _upperPosition : _lowerPosition;

            float currentTime = 0f;

            while (currentTime < 1f)
            {
                currentTime += Time.deltaTime * _moveSpeed;

                float newPos = Mathf.Lerp(startPos, targetPos, currentTime);
                transform.position = new Vector3(transform.position.x, newPos, transform.position.z);
                

                yield return null;
            }

            _audioSource.PlayOneShot(_spearsSound);

            _movingUp = !_movingUp;

            yield return new WaitForSeconds(_delay);
        }
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
