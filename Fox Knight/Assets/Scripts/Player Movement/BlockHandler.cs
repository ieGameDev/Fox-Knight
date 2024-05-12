using UnityEngine;
using static CharacterMovement;

public class BlockHandler : MonoBehaviour
{
    private CharacterMovement _characterMovement;
    public bool RightMouseButtonPressed { get; set; }

    private void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        RightMouseButtonPressed = Input.GetMouseButton(1);

        if (RightMouseButtonPressed)
        {
            _characterMovement.SwitchStateTo(CharacterState.Blocking);
            return;
        }
        else
        {
            _characterMovement.SwitchStateTo(CharacterState.Normal);
            return;
        }
    }

    private void OnDisable()
    {
        RightMouseButtonPressed = false;
    }
}
