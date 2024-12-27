using UnityEngine;
using UnityEngine.Serialization;

public class ShooterBehaviour : MonoBehaviour
{
    //弾のPrefab
    [SerializeField] private GameObject bulletPrefab;

    //弾の発射速度
    [SerializeField] private float shootSpeed = 1000f;
    
    //弾を撃つたびに減るスコア
    [SerializeField] private int shootSubScore = 1;
    
    //弾を撃つときの効果音
    [SerializeField] private AudioClip shootSound;
    
    //弾を撃つときの効果音の音量
    [SerializeField] private float shootSoundVolume = 1f;

    //スコアのオブジェクト
    private ScoreBehaviour _scoreBehaviour;
    
    //シーン内からScoreBehaviourを探してくる
    private void Start()
    {
        _scoreBehaviour = FindObjectOfType<ScoreBehaviour>();
    }
    
    //プレイヤーが画面をタッチしたらタッチした位置から弾を発射する
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //タッチした位置を取得する
            var touchPosition = Input.mousePosition;

            //タッチした位置からRayを飛ばす
            var ray = Camera.main.ScreenPointToRay(touchPosition);

            //弾をRayの方向に向けて生成してPlayerBulletBehaviourをアタッチする
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
            
            //効果音を再生する
            AudioSource.PlayClipAtPoint(shootSound, transform.position, shootSoundVolume);
            
            //弾を発射したらスコアを減らす
            _scoreBehaviour.SubScore(shootSubScore);
        }
    }
}