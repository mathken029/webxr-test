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
        
        //プレイヤーの最初の位置のtransform
        private Vector3 _playerStartPosition;
        
        private void Start()
        {
            _playerBehaviour = FindObjectOfType<PlayerBehaviour>();
            
            //プレイヤーの最初の位置を保存
            _playerStartPosition = _playerBehaviour.transform.position;
            
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
        
        public void StopSpawn()
        {
            CancelInvoke(nameof(SpawnEnemy));
        }
        
        //プレイヤーの初期位置から離れた位置で、上下左右の座標をランダムに敵を生成する
        private void SpawnEnemy()
        {
            var playerTransform = _playerBehaviour.transform;
            
            //プレイヤーの初期位置から離れた位置で敵を生成する
            var randomPosition = _playerStartPosition + playerTransform.forward * Random.Range(spawnDistanceMin, spawnDistanceMax);
            
            //上下もランダムにする
            randomPosition += playerTransform.up * Random.Range(spawnHeightMin, spawnHeightMax);
            
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }
}