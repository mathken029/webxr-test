using UnityEngine;

namespace webxr_test.Scripts.ARShooting
{
    public class EnemySpawnerBehaviour : MonoBehaviour
    {
        //生成するターゲットのプレハブ
        [SerializeField] private GameObject targetPrefab;
        
        //ターゲットを生成する間隔
        [SerializeField] private float spawnInterval = 1f;
        [SerializeField] private float spawnIntervalLast = 0.5f;
        
        private PlayerBehaviour _playerBehaviour;
        
        //プレイヤーの正面のランダムな座標に敵を生成する
        private void Start()
        {
            _playerBehaviour = FindObjectOfType<PlayerBehaviour>();
            
            InvokeRepeating(nameof(SpawnTarget), 0, spawnInterval);
        }
        
        //ターゲットを生成する
        private void SpawnTarget()
        {
            var playerTransform = _playerBehaviour.transform;
            var playerPosition = playerTransform.position;
            var playerForward = playerTransform.forward;
            var randomPosition = playerPosition + playerForward * Random.Range(1f, 3f);
            Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        }
    }
}