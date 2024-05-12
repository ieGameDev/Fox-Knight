using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _levelSelectionMenu;
    [SerializeField] private GameObject _headerOfGame;
    [SerializeField] private GameObject _playButton;

    private void Start()
    {
        StartMenuSequence();
    }

    public void StartButton()
    {
        Time.timeScale = 0f;
        _levelSelectionMenu.SetActive(true);
        _headerOfGame.SetActive(false);
        _playButton.SetActive(false);
    }

    public void StartMenuSequence()
    {
        Time.timeScale = 1f;
        _headerOfGame.SetActive(true);
        _playButton.SetActive(true);
    }
}
