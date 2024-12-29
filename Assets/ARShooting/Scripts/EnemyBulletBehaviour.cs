using UnityEngine;
using webxr_test.Scripts.ARShooting;

public class EnemyBulletBehaviour : BulletBehaviourBase
{
    //減らすスコア
    [SerializeField] private float decreaseScore = 10;
    public float DecreaseScore => decreaseScore;
    
    //PlayerBehaviourに触れたら自身を削除する
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out var playerBehaviour))
        {
            Hit(other);
        }
    }
    
}
