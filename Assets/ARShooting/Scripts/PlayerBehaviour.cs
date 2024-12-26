using UnityEngine;

namespace webxr_test.Scripts.ARShooting
{
    public class PlayerBehaviour : MonoBehaviour
    {
        //減らすスコア
        [SerializeField] private float score = 5;
        
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
            if (other.gameObject.TryGetComponent<EnemyBulletBehaviour>(out var bulletBehaviour))
            {
                //スコアを減らす
                _scoreBehaviour.SubScore(score);
            
                //弾を削除する
                Destroy(other.gameObject);
            }
        }
    }
}