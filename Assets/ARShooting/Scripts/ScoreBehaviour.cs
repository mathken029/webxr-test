using System;
using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class ScoreBehaviour : MonoBehaviour
{
    //スコアを表示するUI
    private TMPro.TextMeshProUGUI _scoreText;
    
    //スコア
    private float score = 0;
    
    //スコアの記録を開始するフラグ
    private bool _isRecording = false;

    private void Start()
    {
        //コンポーネント内のTMPro.TextMeshProUGUIを取得する
        _scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        
        //UnityEditor上で実行している場合はスコアの記録を開始する
        if (Application.isEditor)
        {
            StartRecording();
        }
    }
    
    private void Update()
    {
        //小数点第一位までのスコアを表示する
        _scoreText.text = $"Score: {score:F1}";
    }

    //スコアの記録を開始するフラグをオンにする
    public void StartRecording()
    {
        _isRecording = true;
    }
    
    //スコアの記録を停止するフラグをオフにする
    public void StopRecording()
    {
        _isRecording = false;
    }
    
    //スコアを加算する
    public void AddScore(float point)
    {
        //スコアの記録を開始している場合のみスコアを加算する
        if (_isRecording)
        {
            score += point;
        }
    }
    
    //スコアを減らす
    public void SubScore(float point)
    {
        //スコアの記録を開始している場合のみスコアを減らす
        if (_isRecording)
        {
            score -= point;
        }
    }
    
    //スコアをリセットする
    public void ResetScore()
    {
        score = 0;
    }
    
    //スコアを取得する
    public float GetScore()
    {
        return score;
    }
}
