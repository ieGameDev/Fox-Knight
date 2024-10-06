using UnityEngine;

public class MainMenuLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] _vfxPrefabs;

    private void Start()
    {
        foreach (var prefab in _vfxPrefabs)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
