using UnityEngine;
using UnityEngine.Serialization;

namespace webxr_test.Scripts.ARShooting
{
    public class EnemySpawnerBehaviour : MonoBehaviour
    {
        //生成する敵のプレハブ
        [SerializeField] private GameObject enemyPrefab;
        
        //敵を生成する間隔
        [SerializeField] private float spawnInterval = 1f;
        [SerializeField] private float spawnIntervalLast = 0.5f;
        
        //敵を生成する距離
        [SerializeField] private float spawnDistanceMin = 4f;
        [SerializeField] private float spawnDistanceMax = 6f;
        
        //敵を生成する高さ
        [SerializeField] private float spawnHeightMin = -1f;
        [SerializeField] private float spawnHeightMax = 1f;
        
        private PlayerBehaviour _playerBehaviour;
        
        private void Start()
        {
            _playerBehaviour = FindObjectOfType<PlayerBehaviour>();
            
            //UnityEditor上で実行している場合は敵の生成を開始する
            if (Application.isEditor)
            {
                StartSpawn();
            }
        }
        
        public void StartSpawn()
        {
            InvokeRepeating(nameof(SpawnEnemy), 0, spawnInterval);
        }
        
        //設定した距離離れた位置で、上下左右の座標をランダムに敵を生成する
        private void SpawnEnemy()
        {
            var playerTransform = _playerBehaviour.transform;
            var playerPosition = playerTransform.position;
            var playerForward = playerTransform.forward;
            
            //プレイヤーの前方にランダムな距離だけ敵を生成する
            var randomPosition = playerPosition + playerForward * Random.Range(spawnDistanceMin, spawnDistanceMax);
            
            //上下もランダムにする
            randomPosition += playerTransform.up * Random.Range(spawnHeightMin, spawnHeightMax);
            
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }
}