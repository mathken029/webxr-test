using UnityEngine;

namespace webxr_test.Scripts.ARShooting
{
    public class TitleBehaviour : MonoBehaviour
    {
        private void Start()
        {
            //UnityEditor上で実行している場合は自身を消滅させる
            if (Application.isEditor)
            {
                Destroy(gameObject);
            }
        }
    }
}