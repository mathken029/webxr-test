using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class TimerBehaviour : MonoBehaviour
{
    [SerializeField] private float maxTime = 60f;
    
    //制限時間を表示するUI
    private TMPro.TextMeshProUGUI _timeText;
    
    //60秒をカウントダウンし、0になったらリザルト画面を表示する
    private void Start()
    {
        //コンポーネント内のTMPro.TextMeshProUGUIを取得する
        _timeText = GetComponent<TMPro.TextMeshProUGUI>();
        
        StartCoroutine(CountDown());
    }
    
    private IEnumerator CountDown()
    {
        var time = maxTime;
        while (time > 0)
        {
            _timeText.text = $"Time: {time}";
            yield return new WaitForSeconds(1);
            time--;
        }
        //リザルト画面を表示する
    }
    
    
}
