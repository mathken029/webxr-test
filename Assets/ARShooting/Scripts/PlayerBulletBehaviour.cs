using UnityEngine;
using webxr_test.Scripts.ARShooting;

public class PlayerBulletBehaviour : BulletBehaviourBase
{
    //EnemyBehaviourに触れたら自身を削除する
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyBehaviour>(out var enemyBehaviour))
        {
            Destroy(gameObject);
        }
    }
}
