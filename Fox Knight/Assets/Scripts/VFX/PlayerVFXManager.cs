using System.Collections.Generic;
using UnityEngine;

public class PlayerVFXManager : MonoBehaviour
{
    [Header("Sword VFX")]
    [SerializeField] private GameObject _swordHitPrefab;

    private List<GameObject> _swordHitPool = new List<GameObject>();

    private void Start()
    {
        int swordHitCount = GetSwordHitCount();

        for (int i = 0; i < swordHitCount; i++)
        {
            GameObject vfxInstance = Instantiate(_swordHitPrefab);
            vfxInstance.SetActive(false);
            _swordHitPool.Add(vfxInstance);
        }
    }

    private int GetSwordHitCount()
    {
        SceletonMovement[] sceletons = FindObjectsOfType<SceletonMovement>();
        int countOfHits = 4;
        return sceletons.Length * countOfHits;
    }

    public void PlaySwordHit(Vector3 position)
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
        foreach (GameObject vfx in _swordHitPool)
        {
            if (vfx != null && !vfx.activeInHierarchy)
            {
                return vfx;
            }
        }
        return null;
    }
}
