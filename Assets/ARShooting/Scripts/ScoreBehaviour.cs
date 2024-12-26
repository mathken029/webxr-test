using System;
using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class ScoreBehaviour : MonoBehaviour
{
    //スコアを表示するUI
    private TMPro.TextMeshProUGUI _scoreText;
    
    //スコア
    private int score = 0;

    private void Start()
    {
        //コンポーネント内のTMPro.TextMeshProUGUIを取得する
        _scoreText = GetComponent<TMPro.TextMeshProUGUI>();
    }
    
    private void Update()
    {
        //スコアを表示する
        _scoreText.text = $"Score: {score}";
    }

    //スコアを加算する
    public void AddScore(int point)
    {
        score += point;
    }
    
    //スコアを減らす
    public void SubScore(int point)
    {
        score -= point;
    }
    
    //スコアを取得する
    public int GetScore()
    {
        return score;
    }
    
    //スコアをリセットする
    public void ResetScore()
    {
        score = 0;
    }
}
