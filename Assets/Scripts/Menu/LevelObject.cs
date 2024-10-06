using UnityEngine;
using UnityEngine.UI;

public class LevelObject : MonoBehaviour
{
    [SerializeField] private Image _cup;
    [SerializeField] private Button _levelButton;

    [SerializeField] private Sprite _emptyCup;
    [SerializeField] private Sprite _bronzeCup;
    [SerializeField] private Sprite _silverCup;
    [SerializeField] private Sprite _goldCup;

    public Button LevelButton { get { return _levelButton; } }

    public void UpdateCupSprite(int numberOfSprite)
    {
        switch (numberOfSprite)
        {
            case 0:
                _cup.sprite = _bronzeCup;
                break;
            case 1:
                _cup.sprite = _silverCup;
                break;
            case 2:
                _cup.sprite = _goldCup;
                break;
        }
    }
}
