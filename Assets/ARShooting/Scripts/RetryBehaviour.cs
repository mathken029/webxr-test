using UnityEngine;
using UnityEngine.UI;

namespace webxr_test.Scripts.ARShooting
{
    public class RetryBehaviour : MonoBehaviour
    {
        private Button _retryButton;
        private ScoreBehaviour _scoreBehaviour;
        private TimerBehaviour _timerBehaviour;
        private EnemySpawnerBehaviour _enemySpawnerBehaviour;
        
        private void Start()
        {
            _retryButton = GetComponent<Button>();
            _retryButton.onClick.AddListener(Retry);
            
            //各クラスを取得する
            _scoreBehaviour = FindObjectOfType<ScoreBehaviour>();
            _timerBehaviour = FindObjectOfType<TimerBehaviour>();
            _enemySpawnerBehaviour = FindObjectOfType<EnemySpawnerBehaviour>();
        }
        
        private void Retry()
        {
            //スコアをリセットする
            _scoreBehaviour.ResetScore();
            
            //タイマーをリセットする
            _timerBehaviour.ResetTimer();
            
            //敵の生成を開始する
            _enemySpawnerBehaviour.StartSpawn();
            
            //リトライボタンを非表示にする
            gameObject.SetActive(false);
        }
    }
}