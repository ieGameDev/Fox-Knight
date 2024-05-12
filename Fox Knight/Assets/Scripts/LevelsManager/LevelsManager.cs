using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern void ShowAdv();

    [SerializeField] private GameObject _player;
    private float _restartDelay = 0.5f;
    private int _currentSceneNumber;

    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private ResultUI _resultUI;

    [Header("GUI")]
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject[] _playerUI;
    [SerializeField] private GameObject _statsCanvas;
    [SerializeField] private GameObject _pauseButton;

    [SerializeField] private PlatformSelection _platformSelection;


    private int _numberOfCup;

    private void Start()
    {
        _currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
        LevelStartSequence();
    }

    private void Update()
    {
        if (_player == null)
        {
            StartCoroutine(LevelRestart());
        }
    }

    private IEnumerator LevelRestart()
    {
        yield return new WaitForSeconds(_restartDelay);
        SceneManager.LoadScene(_currentSceneNumber);
    }

    public void NextLocation()
    {
        int nextSceneIndex = _currentSceneNumber + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        PlayerPrefs.SetInt($"CupCollected{_currentSceneNumber}", _numberOfCup);
        PlayerPrefs.Save();

        //ShowAdv();
        AdsManager.Instance.InterstitialAd.ShowAd();
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ChooseCupSprite(int numberOfSprite)
    {
        _numberOfCup = numberOfSprite;
    }

    private void LevelStartSequence()
    {
        PlayerUIControl(false);
        _startPanel.SetActive(true);
        _pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void LevelStartButton()
    {
        Time.timeScale = 1;

        PlayerUIControl(true);
        _pauseButton.SetActive(true);
        _startPanel.SetActive(false);

        _soundManager.PlayStartSounds();
    }

    public void LevelFinishSequence()
    {
        PlayerUIControl(false);
        _pauseButton.SetActive(false);
        _finishPanel.SetActive(true);
        _resultUI.ShowResults();
        Time.timeScale = 0;

        OnLevelComplete();
    }

    private void OnLevelComplete()
    {
        if (_currentSceneNumber == LevelSelectionMenu.UnlockedLevels)
        {
            LevelSelectionMenu.UnlockedLevels++;
            PlayerPrefs.SetInt("UnlockedLevels", LevelSelectionMenu.UnlockedLevels);
            PlayerPrefs.Save();
        }
    }

    public void LevelFinishButton()
    {
        _finishPanel.SetActive(false);
        NextLocation();
    }

    private void PlayerUIControl(bool isTurnOn)
    {
        _statsCanvas.SetActive(isTurnOn);

        foreach (var playerUI in _playerUI)
        {
            if (playerUI != null && _platformSelection.CurrentState == PlatformSelection.PlatformState.Mobile)
            {
                playerUI.SetActive(isTurnOn);
            }
        }
    }
}
