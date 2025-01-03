using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using unityroom.Api;
using webxr_test.Scripts.ARShooting;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class TimerBehaviour : MonoBehaviour
{
    [SerializeField] private float maxTime = 60f;
    [SerializeField] Button retryButton;
    
    private TMPro.TextMeshProUGUI _timeText;
    private EnemySpawnerBehaviour _enemySpawnerBehaviour;
    private ScoreBehaviour _scoreBehaviour;

    
    private void Start()
    {
        //コンポーネント内のTMPro.TextMeshProUGUIを取得する
        _timeText = GetComponent<TMPro.TextMeshProUGUI>();
        DisplayTime(maxTime);
        
        //必要なクラスを取得する
        _enemySpawnerBehaviour = FindObjectOfType<EnemySpawnerBehaviour>();
        _scoreBehaviour = FindObjectOfType<ScoreBehaviour>();
        
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
    
    //タイマーをリセットする
    public void ResetTimer()
    {
        StopAllCoroutines();
        DisplayTime(maxTime);
        StartCoroutine(CountDown());
    }
    
    //60秒をカウントダウンし、0になったらリトライボタンを表示する
    private IEnumerator CountDown()
    {
        var time = maxTime;
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            DisplayTime(time);
        }
        
        //シーン内のすべての敵と弾を消滅させる
        foreach (var enemy in FindObjectsOfType<EnemyBehaviour>())
        {
            Destroy(enemy.gameObject);
        }
        
        foreach (var bullet in FindObjectsOfType<EnemyBulletBehaviour>())
        {
            Destroy(bullet.gameObject);
        }
        
        //敵の生成を停止する
        _enemySpawnerBehaviour.StopSpawn();
        
        //スコアをランキングに送信する
        UnityroomApiClient.Instance.SendScore(1, _scoreBehaviour.GetScore(), ScoreboardWriteMode.HighScoreDesc);
        
        //リトライボタンを表示する
        retryButton.gameObject.SetActive(true);
    }
    
    //時間を表示する
    private void DisplayTime(float time)
    {
        _timeText.text = $"Time: {time}";
    }
}
