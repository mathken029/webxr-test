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
        
        //プレイヤーの初期位置からどれくらい離れた場所に固定で敵を生成するか
        [SerializeField] private float spawnDistance = 2f;
        
        //敵を生成するランダムな座標の範囲
        [SerializeField] private float spawnRandomXMin = -1f;
        [SerializeField] private float spawnRandomXMax = 1f;
        [SerializeField] private float spawnRandomYMin = -1f;
        [SerializeField] private float spawnRandomYMax = 1f;
        [SerializeField] private float spawnRandomZMin = -1f;
        [SerializeField] private float spawnRandomZMax = 1f;
        
        private PlayerBehaviour _playerBehaviour;
        
        //敵を生成する位置の基準
        private Vector3 _enemySpawnPosition;
        
        private void Start()
        {
            _playerBehaviour = FindObjectOfType<PlayerBehaviour>();
            
            //プレイヤーの初期位置から規定の居r離れた場所に敵を生成する場所を設定する
            _enemySpawnPosition = _playerBehaviour.transform.position + _playerBehaviour.transform.forward * spawnDistance;
            
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
            //敵を生成する位置の基準からランダムな位置を設定する
            var randomPosition = _enemySpawnPosition + new Vector3(
                Random.Range(spawnRandomXMin, spawnRandomXMax),
                Random.Range(spawnRandomYMin, spawnRandomYMax),
                Random.Range(spawnRandomZMin, spawnRandomZMax)
            );
            
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }
}