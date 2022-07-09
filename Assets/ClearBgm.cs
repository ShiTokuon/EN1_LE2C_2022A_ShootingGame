using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBgm : MonoBehaviour
{
    // Start is called before the first frame update

    //敵の数を数える用の変数
    private GameObject[] enemy;

    public AudioSource audio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //シーンに存在しているEnemyタグを持っているオブジェクト
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //シーンに1体もEnemyがいなくなったら
        if (enemy.Length == 0)
        {
            audio.Play();
        }
    }
}
