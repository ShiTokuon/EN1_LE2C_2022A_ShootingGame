using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy�̗̑͗p�ϐ�
    private int enemyhp;
    // Start is called before the first frame update
    void Start()
    {
        //�������ɑ̗͂��w�肵�Ă���
        enemyhp = 3;       
    }

    // Update is called once per frame
    void Update()
    {
        //�����̗͂�0�ȉ��ɂȂ�����
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
