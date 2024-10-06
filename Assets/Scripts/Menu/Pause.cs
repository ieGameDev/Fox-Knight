using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject[] _characterControllerUI;
    [SerializeField] private GameObject _characterStaminaUI;

    [SerializeField] private PlatformSelection _platformSelection;

    private int _currentSceneNumber;

    private void Start()
    {
        _currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
        _pausePanel.SetActive(false);
    }

    public void PauseButton()
    {
        _pausePanel?.SetActive(true);
        _pauseButton?.SetActive(false);
        _characterStaminaUI.SetActive(false);
        foreach (var UI in _characterControllerUI)
        {
            if (UI != null && _platformSelection.CurrentState == PlatformSelection.PlatformState.Mobile)
            {
                UI.SetActive(false);
            }
        }
        Time.timeScale = 0f;
    }

    public void PlayButton()
    {
        _pausePanel?.SetActive(false);
        _pauseButton?.SetActive(true);
        _characterStaminaUI.SetActive(true);
        foreach (var UI in _characterControllerUI)
        {
            if (UI != null && _platformSelection.CurrentState == PlatformSelection.PlatformState.Mobile)
            {
                UI.SetActive(true);
            }
        }
        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(_currentSceneNumber);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
