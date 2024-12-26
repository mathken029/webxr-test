using System;
using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class ScoreBehaviour : MonoBehaviour
{
    //スコアを表示するUI
    private TMPro.TextMeshProUGUI _scoreText;
    
    //スコア
    private float score = 0;

    private void Start()
    {
        //コンポーネント内のTMPro.TextMeshProUGUIを取得する
        _scoreText = GetComponent<TMPro.TextMeshProUGUI>();
    }
    
    private void Update()
    {
        //小数点第一位までのスコアを表示する
        _scoreText.text = $"Score: {score:F1}";
    }

    //スコアを加算する
    public void AddScore(float point)
    {
        score += point;
    }
    
    //スコアを減らす
    public void SubScore(float point)
    {
        score -= point;
    }
}
