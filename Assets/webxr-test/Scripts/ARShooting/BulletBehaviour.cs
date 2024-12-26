using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    //削除されるまでの秒数
    [SerializeField] private float destroyTime = 2f;
    
    //生成されてから2秒後に削除する
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    
    //Shooter以外に触れたら削除する
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ShooterBehaviour>(out var shooterBehaviour))
        {
            //何もしない
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
