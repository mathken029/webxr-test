using UnityEngine;

public abstract class BulletBehaviourBase : MonoBehaviour
{
    //削除されるまでの秒数
    [SerializeField] private float destroyTime = 2f;
    
    //生成されてから2秒後に削除する
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
