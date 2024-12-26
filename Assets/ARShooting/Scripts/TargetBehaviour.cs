using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    //このターゲットの加算スコア
    [SerializeField] private int score = 10;
    
    //スコアのオブジェクト
    private ScoreBehaviour _scoreBehaviour;
    
    //シーン内からScoreBehaviourを探してくる
    private void Start()
    {
        _scoreBehaviour = FindObjectOfType<ScoreBehaviour>();
    }
    
    //BulletBehaviourがコライダーに触れたらスコアを加算する
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<BulletBehaviour>(out var bulletBehaviour))
        {
            //スコアを加算する
            _scoreBehaviour.AddScore(score);
            
            //ターゲットを削除する
            Destroy(gameObject);
        }
    }
}
