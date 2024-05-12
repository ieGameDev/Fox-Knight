using UnityEngine;

public class PlatformSelection : MonoBehaviour
{
    [Header("Mobile Handler")]
    [SerializeField] private GameObject[] _playerController;
    [SerializeField] private AttackHandler _attackHandler;

    public enum PlatformState
    {
        Mobile, Desktop
    }
    public PlatformState CurrentState;

    private void OnValidate()
    {
        SwitchStateTo(CurrentState);
    }

    public void SwitchStateTo(PlatformState newState)
    {
        switch (CurrentState)
        {
            case PlatformState.Mobile:
                foreach (var controller in _playerController)
                {
                    if (controller != null)
                    {
                        controller.SetActive(true);
                    }
                }

                if (_attackHandler != null)
                {
                    _attackHandler.enabled = false;
                }

                break;
            case PlatformState.Desktop:
                foreach (var controller in _playerController)
                {
                    if (controller != null)
                    {
                        controller.SetActive(false);
                    }
                }

                if (_attackHandler != null)
                {
                    _attackHandler.enabled = true;
                }

                break;
        }

        CurrentState = newState;
    }
}
