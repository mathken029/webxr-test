using UnityEngine;
using webxr_test.Scripts.ARShooting;

public class EnemyBehaviour : MonoBehaviour
{
    private ScoreBehaviour _scoreBehaviour;
    private PlayerBehaviour _playerBehaviour;
    
    private void Start()
    {
        _scoreBehaviour = FindObjectOfType<ScoreBehaviour>();
        _playerBehaviour = FindObjectOfType<PlayerBehaviour>();
    }
    
    //BulletBehaviourがコライダーに触れたら、プレイヤーとの距離が近いほど高いスコアを加算する
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<BulletBehaviour>(out var bulletBehaviour))
        {
            //プレイヤーとの距離を取得する
            var distance = Vector3.Distance(transform.position, _playerBehaviour.transform.position);
            
            //距離をスコアとして加算する
            _scoreBehaviour.AddScore(distance);
            
            //ターゲットを削除する
            Destroy(gameObject);
        }
    }
}
