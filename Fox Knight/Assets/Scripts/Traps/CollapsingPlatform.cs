using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    [SerializeField] private float _collapsingSpeed;

    private Vector3 _originalPosition;
    private bool _isCollapsing = false;

    private void Start()
    {
        _originalPosition = transform.position;
    }

    private void Update()
    {
        if (_isCollapsing)
        {
            transform.position -= Vector3.up * _collapsingSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _originalPosition, _collapsingSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isCollapsing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isCollapsing = false;
        }
    }
}
