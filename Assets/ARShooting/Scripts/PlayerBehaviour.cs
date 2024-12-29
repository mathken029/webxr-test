using UnityEngine;

namespace webxr_test.Scripts.ARShooting
{
    public class PlayerBehaviour : MonoBehaviour
    {
        //ScoreBehaviourを取得する
        private ScoreBehaviour _scoreBehaviour;
        
        private void Start()
        {
            //ScoreBehaviourを取得する
            _scoreBehaviour = FindObjectOfType<ScoreBehaviour>();
        }
        
        //弾が触れたらスコアを減らす
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<EnemyBulletBehaviour>(out var enemyBulletBehaviour))
            {
                //スコアを減らす
                _scoreBehaviour.SubScore(enemyBulletBehaviour.DecreaseScore);
            
                //弾を削除する
                Destroy(other.gameObject);
            }
        }
    }
}