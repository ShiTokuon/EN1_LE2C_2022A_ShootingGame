using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBgm : MonoBehaviour
{
    // Start is called before the first frame update

    //�G�̐��𐔂���p�̕ϐ�
    private GameObject[] enemy;

    public AudioSource audio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�V�[���ɑ��݂��Ă���Enemy�^�O�������Ă���I�u�W�F�N�g
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //�V�[����1�̂�Enemy�����Ȃ��Ȃ�����
        if (enemy.Length == 0)
        {
            audio.Play();
        }
    }
}
