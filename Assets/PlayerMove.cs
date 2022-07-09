using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //カメラから見た画面左上の座標を入れる変数
    Vector3 LeftBottom;

    //カメラから見た画面右上の座標を入れる座標
    Vector3 RightTop;

    //子オブジェクトのサイズを入れるための変数
    private float Left, Right, Top, Bottom;

    public GameObject shiftText;

    // Start is called before the first frame update
    void Start()
    {
        shiftText.SetActive(false);

        //カメラとプレイヤーの距離を測る(表示画面の四隅を設定)
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        //スクリーン画面左下の位置を設定する
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        //スクリーン画面右上の位置を設定する
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        //子オブジェクトの数だけループ処理を行う
        foreach (Transform child in gameObject.transform)
        {
            //子オブジェクトの中で一番右の位置にいたなら
            if (child.localPosition.x >= Right)
            {
                //子オブジェクトのローカルX座標を右端用の変数に代入する
                Right = child.transform.localPosition.x;
            }
            //子オブジェクトの中で一番左にいたなら
            if (child.localPosition.x <= Left)
            {
                //子オブジェクトのローカルX座標を左端用の変数に代入する
                Left = child.transform.localPosition.x;
            }
            //子オブジェクトの中で一番上にいたら
            if (child.localPosition.z >= Top)
            {
                //子オブジェクトのローカルZ座標を上端用の変数に代入する
                Top = child.transform.position.z;
            }
            //子オブジェクトの中で一番下にいたら
            if (child.localPosition.z <= Bottom)
            {
                Bottom = child.transform.position.z;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動処理
        Vector3 pos = transform.position;

        shiftText.SetActive(false);

        //右矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            //右方向に0.1動く
            pos.x += 0.1f;

            shiftText.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //右方向に0.5動く
            pos.x += 0.5f;

            shiftText.SetActive(false);
        }

        //左矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            //左方向に0.1動く
            pos.x -= 0.1f;

            shiftText.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //左方向に0.5動く
            pos.x -= 0.5f;

            shiftText.SetActive(false);
        }

        //上矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            //上方向に0.1動く
            pos.z += 0.1f;

            shiftText.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            //上方向に0.5動く
            pos.z += 0.5f;

            shiftText.SetActive(false);
        }

        //下矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            //下方向に0.1動く
            pos.z -= 0.1f;

            shiftText.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //下方向に0.5動く
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
