using UnityEngine;

public class DiamondCollection : Collections
{
    private void Start()
    {
        StartCounting();
    }

    protected override void StartCounting()
    {
        Diamond[] diamonds = FindObjectsOfType<Diamond>();
        _countOfItemsOnLevel = diamonds.Length;
        UpdateText();
    }
}
