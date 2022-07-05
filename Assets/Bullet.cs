using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //敵の数を数える用の変数
    private GameObject[] enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //弾のワールド座標を取得
        Vector3 pos = transform.position;

        //上にまっすぐ飛ぶ
        pos.z += 0.05f;

        //弾の移動
        transform.position = new Vector3(pos.x, pos.y, pos.z);

        //シーンに存在しているEnemyタグを持っているオブジェクト
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //一定距離飛んだら消滅する
        if(pos.z >= 20)
        {
            Destroy(this.gameObject);
        }

        //シーンに1体もEnemyがいなくなったら弾を消す
        if (enemy.Length == 0)
        {
            Destroy(this.gameObject);
        }
    }

    //当たり判定用関数
    private void OnTriggerEnter(Collider other)
    {
        //もし当たったオブジェクトのタグがEnemyだったら
        if(other.gameObject.tag == "Enemy")
        {
            //当たったオブジェクトのEnemyスクリプトを呼び出してDamage関数を実行させる
            other.GetComponent<Enemy>().Damage();
        }
    }
}
