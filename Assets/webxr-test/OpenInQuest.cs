using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInQuest : MonoBehaviour
{
    [SerializeField] private string urlOpenInQuest;
    
    public void openInQuest()
    {
        Application.OpenURL(urlOpenInQuest);//""の中には開きたいWebページのURLを入力します
    }
}
