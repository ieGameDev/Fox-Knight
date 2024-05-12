using UnityEngine;

public class GravityManager : MonoBehaviour
{
    [Header("Gravity Handling")]
    private float _gravityForce = 9.8f;
    public float GravityForce
    {
        set
        {
            if (value >= 0)
                _gravityForce = value;
        }
    }

    private CharacterMovement _characterMovement;
    private CharacterController _characterController;

    private void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _characterController = GetComponent<CharacterController>();
    }

    public void GravityHandling()
    {
        if (!_characterController.isGrounded)
        {
            _characterMovement.velocityDirection.y -= _gravityForce * Time.deltaTime;
        }
    }
}
