// Assets/Editor/BuildProcessor.cs
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.IO;
using UnityEngine;
using unityroom.Api;

public class BuildProcessor : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        string hmacKeyPath = "Assets/Editor/hmackey.txt";
        string hmacKey = File.ReadAllText(hmacKeyPath);

        // UnityroomApiClientのHmacKeyフィールドに値を設定
        UnityroomApiClient unityroomApiClient = Object.FindObjectOfType<UnityroomApiClient>();
        if (unityroomApiClient != null)
        {
            unityroomApiClient.SetHmacKey(hmacKey);
            EditorUtility.SetDirty(unityroomApiClient);
        }
        else
        {
            Debug.LogError("UnityroomApiClientがシーンに見つかりませんでした。");
        }
    }
}