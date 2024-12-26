using UnityEngine;

namespace webxr_test.Scripts.ARShooting
{
    public class TargetSpawnerBehaviour : MonoBehaviour
    {
        //生成するターゲットのプレハブ
        [SerializeField] private GameObject targetPrefab;
        
        //プレイヤーのゲームオブジェクト
        [SerializeField] private GameObject player;
        
        //ターゲットを生成する間隔
        [SerializeField] private float spawnInterval = 1f;
        [SerializeField] private float spawnIntervalLast = 0.5f;
        
        //プレイヤーの正面のランダムな座標にターゲットを生成する
        private void Start()
        {
            InvokeRepeating(nameof(SpawnTarget), 0, spawnInterval);
        }
        
        //ターゲットを生成する
        private void SpawnTarget()
        {
            var playerTransform = player.transform;
            var playerPosition = playerTransform.position;
            var playerForward = playerTransform.forward;
            var randomPosition = playerPosition + playerForward * Random.Range(1f, 3f);
            Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        }
    }
}