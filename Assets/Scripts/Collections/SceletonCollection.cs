using UnityEngine;

public class SceletonCollection : Collections
{    
    private void Start()
    {
        StartCounting();
    }

    protected override void StartCounting()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        _countOfItemsOnLevel = enemies.Length;
        UpdateText();
    }
}
