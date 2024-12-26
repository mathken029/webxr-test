using UnityEngine;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

public class CallToggleVRClass
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void ToggleVR();
#endif

    public void CallToggleVR()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ToggleVR();
#endif
    }
}

public class CallToggleVR : MonoBehaviour
{
    CallToggleVRClass callToggleVRClass;

    public void callToggleVR()
    {
        callToggleVRClass = new CallToggleVRClass();
        callToggleVRClass.CallToggleVR();
    }
}