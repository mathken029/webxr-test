using UnityEngine;

public abstract class BulletBehaviourBase : MonoBehaviour
{
    //削除されるまでの秒数
    [SerializeField] protected float destroyTime = 20f;
    
    //ダメージを与えたときの効果音
    [SerializeField] protected AudioClip damageSound;
    
    //ダメージを与えたときの効果音の音量
    [SerializeField] protected float damageSoundVolume = 1f;
    
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    
    //相手にヒットしたときの処理
    protected void Hit(Collider other)
    {
        AudioSource.PlayClipAtPoint(damageSound, transform.position, damageSoundVolume);
        Destroy(gameObject, damageSound.length);
    }
}
