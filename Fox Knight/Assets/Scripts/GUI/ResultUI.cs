using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [Header("PlayerUI")]
    [SerializeField] private TextMeshProUGUI _countOfDiamonds;
    [SerializeField] private TextMeshProUGUI _countOfSceletons;

    [Header("Finish Result")]
    [SerializeField] private DiamondCollection _diamondCollection;
    [SerializeField] private SceletonCollection _sceletonCollection;
    [SerializeField] private TextMeshProUGUI _resultCountOfDiamonds;
    [SerializeField] private TextMeshProUGUI _resultCountOfSceletons;
    [SerializeField] private Image _resultCup;
    [SerializeField] private Sprite[] _cups;
    [SerializeField] private LevelsManager _levelsManager;


    public void ShowResults()
    {
        if (_countOfDiamonds != null && _countOfSceletons != null)
        {
            _resultCountOfDiamonds.text = _countOfDiamonds.text;
            _resultCountOfSceletons.text = _countOfSceletons.text;
        }

        if (GoldResult())
        {
            _resultCup.sprite = _cups[2];
            _levelsManager.ChooseCupSprite(2);
        }
        else if (SilverResult())
        {
            _resultCup.sprite = _cups[1];
            _levelsManager.ChooseCupSprite(1);
        }
        else
        {
            _resultCup.sprite = _cups[0];
            _levelsManager.ChooseCupSprite(0);
        }
    }

    private bool GoldResult()
    {
        return _diamondCollection.NumberOfCollectedItems == _diamondCollection.CountOfItemsOnLevel &&
            _sceletonCollection.NumberOfCollectedItems == _sceletonCollection.CountOfItemsOnLevel;
    }

    private bool SilverResult()
    {
        var resultInPercentage = (((float)_diamondCollection.NumberOfCollectedItems + _sceletonCollection.NumberOfCollectedItems) /
            ((float)_diamondCollection.CountOfItemsOnLevel + _sceletonCollection.CountOfItemsOnLevel)) * 100;
        return resultInPercentage > 40 && resultInPercentage < 100;
    }
}