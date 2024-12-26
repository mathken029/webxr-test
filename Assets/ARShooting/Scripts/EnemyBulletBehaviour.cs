using UnityEngine;
using webxr_test.Scripts.ARShooting;

public class EnemyBulletBehaviour : BulletBehaviourBase
{
    //PlayerBehaviourに触れたら自身を削除する
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out var playerBehaviour))
        {
            Destroy(gameObject);
        }
    }
}
