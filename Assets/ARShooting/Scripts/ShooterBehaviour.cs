using UnityEngine;

public class ShooterBehaviour : MonoBehaviour
{
    //弾のPrefab
    [SerializeField] private GameObject bulletPrefab;

    //弾の発射速度
    [SerializeField] private float shootSpeed = 1000f;

    //プレイヤーが画面をタッチしたらタッチした位置から弾を発射する
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //タッチした位置を取得する
            var touchPosition = Input.mousePosition;

            //タッチした位置からRayを飛ばす
            var ray = Camera.main.ScreenPointToRay(touchPosition);

            //弾を発射する
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            //Rayが当たった位置に向かって弾を発射する
            if (Physics.Raycast(ray, out var hit))
            {
                bullet.GetComponent<Rigidbody>().AddForce((hit.point - transform.position).normalized * shootSpeed);
            }
            else
            {
                //Rayが当たらなかった場合、Rayの方向に弾を発射する
                bullet.GetComponent<Rigidbody>().AddForce(ray.direction * shootSpeed);
            }
        }
    }
}