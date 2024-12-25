using UnityEngine;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

public class CallToggleARClass
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void ToggleAR();
#endif

    public void CallToggleAR()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ToggleAR();
#endif
    }
}

public class CallToggleAR : MonoBehaviour
{
    CallToggleARClass callToggleARClass;

    public void callToggleAR()
    {
        callToggleARClass = new CallToggleARClass();
        callToggleARClass.CallToggleAR();
    }
}