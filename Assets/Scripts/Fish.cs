using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 嬴鱼的动作脚本
/// </summary>
public class Fish : MonoBehaviour
{

    public GameObject player;
    private PlayerControllor pc;

    // 判断是否开始行动
    private bool isMove = false;

    // 判断是否开始攻击
    private bool isAttack = false;
    private float attackTimer; // 攻击计时器
    public float attackTime = 1; // 攻击间隔 秒
    public float speed;

    public float attackSpeed;

    private Vector2 position; // 冲刺方向

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Hero");
        pc = player.GetComponent<PlayerControllor>();
        speed = pc.speed;
        attackTimer = attackTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (isMove)
        {
            // 相对移动
            attackTimer -= Time.deltaTime;
            if (attackTimer == 0)
            {
                Vector2 palyerPos = player.transform.position;
                Vector2 finshPos = transform.position;
                Vector2 v = palyerPos - finshPos;
                position = v / Vector2.Distance(finshPos, palyerPos);
            }
            if (attackTimer <= 0)
            {
                // 获取玩家坐标并朝向移动攻击，碰撞后消失

                sprint(position);
                // attackTimer = attackTime;
            }
            else
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
        }
        else
        {
            float offest = transform.position.x - player.transform.position.x;
            if (offest <= 7)
            {
                isMove = true;
                Debug.Log("Fish isMove : " + isMove + "offest : " + offest);
            }
        }
    }

    // 在玩家视野内 停留一秒，然后对其冲刺
    void OnBecameVisible()
    {
        // isMove = true;
        // Debug.Log("isview");

    }

    private void OnBecameInvisible()
    {
        Debug.Log("noview");
        Destroy(this.gameObject);
    }

    // 冲刺动作
    private void sprint(Vector2 position)
    {
        transform.Translate(position * Time.deltaTime * attackSpeed);
    }
}