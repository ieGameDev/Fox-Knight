using System.Collections.Generic;
using UnityEngine;

public class DiamondPool : MonoBehaviour
{
    [Header("Diamond VFX")]
    [SerializeField] private GameObject _diamondVFXPrefab;
    private List<GameObject> _diamondVFXPool = new List<GameObject>();

    private void Start()
    {
        int diamondsCount = GetDiamondsCount();

        for (int i = 0; i < diamondsCount; i++)
        {
            GameObject vfxInstance = Instantiate(_diamondVFXPrefab);
            vfxInstance.SetActive(false);
            _diamondVFXPool.Add(vfxInstance);
        }
    }

    private int GetDiamondsCount()
    {
        Diamond[] diamonds = FindObjectsOfType<Diamond>();
        return diamonds.Length;
    }

    public void GetDiamondVFX(Vector3 position)
    {
        GameObject vfxInstance = GetNextAvailableVFX();
        if (vfxInstance != null)
        {
            vfxInstance.transform.position = position;
            vfxInstance.SetActive(true);
        }
    }

    private GameObject GetNextAvailableVFX()
    {
        foreach (GameObject vfx in _diamondVFXPool)
        {
            if (vfx != null && !vfx.activeInHierarchy)
            {
                return vfx;
            }
        }
        return null;
    }
}
