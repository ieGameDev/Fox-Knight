using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionMenu : MonoBehaviour
{
    private MainMenu _mainMenu;

    [SerializeField] private LevelObject[] _levelObjects;

    public static int CurrentLevel;
    public static int UnlockedLevels;

    private void Start()
    {
        _mainMenu = GetComponentInParent<MainMenu>();
        UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);

        UpdateUnlockedLevels();
        UpdateCupSprites();
    }

    private void UpdateUnlockedLevels()
    {
        for (int i = 0; i < _levelObjects.Length; i++)
        {
            _levelObjects[i].LevelButton.interactable = (i < UnlockedLevels);
        }
    }

    private void UpdateCupSprites()
    {
        for (int i = 0; i < _levelObjects.Length; i++)
        {
            int numberOfSprite = PlayerPrefs.GetInt($"CupCollected{i + 1}", -1);
            _levelObjects[i].UpdateCupSprite(numberOfSprite);
        }
    }

    public void BackButton()
    {
        _mainMenu.StartMenuSequence();
        gameObject.SetActive(false);
    }

    public void LevelButton(int sceneNumber)
    {
        if (sceneNumber < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneNumber);
        }
        else
        {
            Debug.Log($"Scene with build index: {sceneNumber} doesn't exist in build settings.");
        }
    }

    public void LoadLastUnlockedLevel()
    {
        int lastUnlockedLevel = UnlockedLevels;

        if (lastUnlockedLevel < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(lastUnlockedLevel);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
