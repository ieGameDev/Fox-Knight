using System.Runtime.InteropServices;
using UnityEngine;
using static PlatformSelection;

public class Yandex : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern void TypeOfDevice();

    [SerializeField] private PlatformSelection _platformSelection;

    private void Awake()
    {
        //TypeOfDevice();
    }

    //public void SetDevice(int isMobile)
    //{
    //    if (isMobile == 0)
    //    {
    //        _platformSelection.SwitchStateTo(PlatformState.Desktop);
    //    }
    //    else
    //    {
    //        _platformSelection.SwitchStateTo(PlatformState.Mobile);
    //    }
    //}
}
