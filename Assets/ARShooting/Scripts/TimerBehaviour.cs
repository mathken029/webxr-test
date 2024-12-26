using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class TimerBehaviour : MonoBehaviour
{
    [SerializeField] private float maxTime = 60f;
    
    //制限時間を表示するUI
    private TMPro.TextMeshProUGUI _timeText;
    
    private void Start()
    {
        //コンポーネント内のTMPro.TextMeshProUGUIを取得する
        _timeText = GetComponent<TMPro.TextMeshProUGUI>();
        DisplayTime(maxTime);
        
        //UnityEditor上で実行している場合はタイマーをスタートする
        if (Application.isEditor)
        {
            StartTimer();
        }
    }
    
    //タイマーをスタートする
    public void StartTimer()
    {
        StartCoroutine(CountDown());
    }
    
    //60秒をカウントダウンし、0になったらリトライボタンを表示する
    private IEnumerator CountDown()
    {
        var time = maxTime;
        while (time > 0)
        {
            DisplayTime(time);
            yield return new WaitForSeconds(1);
            time--;
        }
        
        //リトライボタンを表示する
    }
    
    //時間を表示する
    private void DisplayTime(float time)
    {
        _timeText.text = $"Time: {time}";
    }
}
