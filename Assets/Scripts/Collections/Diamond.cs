using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private float _diamondRotationSpeed = 50f;
    private DiamondCollection _diamondCollection;
    private DiamondSound _sound;    
    private DiamondPool _pool;

    private float _sinSpeed = 5f;
    private float _sinAmplitude = 0.2f;
    private Vector3 _startPosition;

    private void Start()
    {
        _diamondCollection = GetComponentInParent<DiamondCollection>();
        _sound = GetComponentInParent<DiamondSound>();
        _pool = GetComponentInParent<DiamondPool>();

        _startPosition = transform.position;        
    }    

    private void Update()
    {
        transform.Rotate(Vector3.forward * _diamondRotationSpeed * Time.deltaTime);

        float floatOffset = Mathf.Sin(Time.time * _sinSpeed) * _sinAmplitude;
        transform.position = _startPosition + new Vector3(0, floatOffset, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _diamondCollection.AddOne();

            _pool.GetDiamondVFX(transform.position);

            _sound.PlayDiamondSound();
            Destroy(gameObject);
        }
    }    
}
