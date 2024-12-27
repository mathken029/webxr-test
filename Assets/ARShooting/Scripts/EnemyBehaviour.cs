using UnityEngine;
using webxr_test.Scripts.ARShooting;

public class EnemyBehaviour : MonoBehaviour
{
    //プレイヤーに向かって弾を撃つ間隔
    [SerializeField] private float shootInterval = 2f;
    
    //弾のPrefab
    [SerializeField] private GameObject bulletPrefab;
    
    //弾の速度
    [SerializeField] private float bulletSpeed = 1000f;
    
    //スコアの分子
    [SerializeField] private float scoreNumerator = 50;
    
    private ScoreBehaviour _scoreBehaviour;
    private PlayerBehaviour _playerBehaviour;
    
    private void Start()
    {
        _scoreBehaviour = FindObjectOfType<ScoreBehaviour>();
        _playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        
        //プレイヤーに向かって弾を撃つ
        InvokeRepeating(nameof(Shoot), 0, shootInterval);
    }
    
    //プレイヤーに向かってゆっくりと重力の影響を受けずにまっすぐに飛ぶ弾を撃つ
    private void Shoot()
    {
        //プレイヤーの位置を取得する
        var playerPosition = _playerBehaviour.transform.position;
        
        //弾を90度回転して生成してEnemyBulletBehaviourをアタッチする
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.AddComponent<EnemyBulletBehaviour>();
        
        //プレイヤーに向かってゆっくりと重力の影響を受けずにまっすぐに飛ぶ弾を打つ
        bullet.GetComponent<Rigidbody>().AddForce((playerPosition - transform.position).normalized * bulletSpeed);
    }
    
    //BulletBehaviourがコライダーに触れたら、プレイヤーとの距離が近いほど高いスコアを加算する
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBulletBehaviour>(out var bulletBehaviour))
        {
            //プレイヤーとの距離を取得する
            var distance = Vector3.Distance(transform.position, _playerBehaviour.transform.position);
            
            //距離が離れているほど高いスコアを加算する
            _scoreBehaviour.AddScore(scoreNumerator / distance);
            
            //ターゲットを削除する
            Destroy(gameObject);
        }
    }
}
