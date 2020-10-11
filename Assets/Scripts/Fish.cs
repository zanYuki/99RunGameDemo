using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 嬴鱼的动作脚本
/// </summary>
public class Fish : MonoBehaviour {

    public GameObject player;

    // 判断是否开始行动
    private bool isMove = false;

    public float speed = 2f;
    // Start is called before the first frame update
    void Start () {
        player = GameObject.FindWithTag ("Hero");
    }

    // Update is called once per frame
    void Update () {
        if (isMove) {
            // 获取玩家坐标并朝向移动攻击，碰撞后消失
            Vector2 palyerPos = player.transform.position;
            Vector2 finshPos = transform.position;
            Vector2 v = palyerPos - finshPos;
            transform.Translate (v / Vector2.Distance (finshPos, palyerPos) * Time.deltaTime * speed);
        }
    }

    // 在玩家视野内
    void OnBecameVisible () {
        isMove = true;
        Debug.Log ("isview");

    }

    private void OnBecameInvisible () {
        Debug.Log ("noview");
        isMove = false;
    }
}