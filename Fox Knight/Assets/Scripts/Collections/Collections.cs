using TMPro;
using UnityEngine;

public abstract class Collections : MonoBehaviour
{
    [Header("Collection Settings")]
    [SerializeField] protected int _numberOfCollectedItems;
    [SerializeField] protected int _countOfItemsOnLevel;
    [SerializeField] protected TextMeshProUGUI _text;

    public int NumberOfCollectedItems => _numberOfCollectedItems;
    public int CountOfItemsOnLevel => _countOfItemsOnLevel;

    protected abstract void StartCounting();

    public void AddOne()
    {
        _numberOfCollectedItems++;
        UpdateText();
    }

    protected virtual void UpdateText()
    {
        if (_text != null)
        {
            _text.text = $"{_numberOfCollectedItems}/{_countOfItemsOnLevel}";
        }
    }
}
