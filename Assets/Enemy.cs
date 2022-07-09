using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemyの体力用変数
    public int enemyhp;

    // Start is called before the first frame update
    void Start()
    {
        //生成時に体力を指定しておく
        enemyhp = 3;       
    }

    // Update is called once per frame
    void Update()
    {
        //もし体力が0以下になったら
        if (enemyhp <= 0)
        {
            Destroy(this.gameObject);
        }       
    }

    public void Damage()
    {
        enemyhp = enemyhp - 1;

        Debug.Log(enemyhp);
    }
}
