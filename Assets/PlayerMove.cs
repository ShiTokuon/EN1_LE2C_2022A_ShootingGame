using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�J�������猩����ʍ���̍��W������ϐ�
    Vector3 LeftBottom;

    //�J�������猩����ʉE��̍��W��������W
    Vector3 RightTop;

    //�q�I�u�W�F�N�g�̃T�C�Y�����邽�߂̕ϐ�
    private float Left, Right, Top, Bottom;

    public GameObject shiftText;

    // Start is called before the first frame update
    void Start()
    {
        shiftText.SetActive(false);

        //�J�����ƃv���C���[�̋����𑪂�(�\����ʂ̎l����ݒ�)
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        //�X�N���[����ʍ����̈ʒu��ݒ肷��
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        //�X�N���[����ʉE��̈ʒu��ݒ肷��
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        //�q�I�u�W�F�N�g�̐��������[�v�������s��
        foreach (Transform child in gameObject.transform)
        {
            //�q�I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if (child.localPosition.x >= Right)
            {
                //�q�I�u�W�F�N�g�̃��[�J��X���W���E�[�p�̕ϐ��ɑ������
                Right = child.transform.localPosition.x;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԍ��ɂ����Ȃ�
            if (child.localPosition.x <= Left)
            {
                //�q�I�u�W�F�N�g�̃��[�J��X���W�����[�p�̕ϐ��ɑ������
                Left = child.transform.localPosition.x;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԏ�ɂ�����
            if (child.localPosition.z >= Top)
            {
                //�q�I�u�W�F�N�g�̃��[�J��Z���W����[�p�̕ϐ��ɑ������
                Top = child.transform.position.z;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԉ��ɂ�����
            if (child.localPosition.z <= Bottom)
            {
                Bottom = child.transform.position.z;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̈ړ�����
        Vector3 pos = transform.position;

        shiftText.SetActive(false);

        //�E���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            //�E������0.1����
            pos.x += 0.1f;

            shiftText.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //�E������0.5����
            pos.x += 0.5f;

            shiftText.SetActive(false);
        }

        //�����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            //��������0.1����
            pos.x -= 0.1f;

            shiftText.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //��������0.5����
            pos.x -= 0.5f;

            shiftText.SetActive(false);
        }

        //����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            //�������0.1����
            pos.z += 0.1f;

            shiftText.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            //�������0.5����
            pos.z += 0.5f;

            shiftText.SetActive(false);
        }

        //�����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            //��������0.1����
            pos.z -= 0.1f;

            shiftText.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //��������0.5����
            pos.z -= 0.5f;

            shiftText.SetActive(false);
        }

        transform.position = new Vector3(
            Mathf.Clamp(pos.x, LeftBottom.x + transform.localScale.x - Left, RightTop.x - transform.localScale.x - Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z - Bottom, RightTop.z - transform.localScale.z - Top)
            );
    }
}
