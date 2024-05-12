using UnityEngine;

public class ResetAllSaves : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
}
