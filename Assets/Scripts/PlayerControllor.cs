using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour {

    //最大健康值
    private int maxHealth = 10;
    //当前健康值
    private int currentHealth;
    //其他脚本可获取最大健康值

    // 初始速度
    private float speed = 10f;
    // 无敌时间
    private float invincibleTime = 2f;
    // 无敌计时器
    private float invincibleTimer;
    // 无敌状态
    private bool isInvincible;
    Rigidbody2D player;

    // private Animator animator;
    private BoxCollider2D boxCollider;
    //private GameManager gameManager;

    private Vector2 boxSize;

    public float jumpForce = 2f; // 跳跃力度
    private bool IsGround = true; // 是否在地板上
    private bool canJump = true; // 是否可以起跳
    public int MyMaxHealth { get { return maxHealth; } }
    //其他脚本可获取当前健康值
    public int MyCurrentHealth { get { return currentHealth; } }
    // Start is called before the first frame update
    void Start () {
        player = GetComponent<Rigidbody2D> ();
        // rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D> ();
        //初始化生命值
        currentHealth = maxHealth / 2;
        //更新生命条与子弹数量
        UIManager.instance.UpdateHealthBar (currentHealth, maxHealth);

    }

    // Update is called once per frame
    void Update () {
        transform.Translate (Vector2.right * Time.deltaTime * speed);
        //控制跳跃
        if (Input.GetKeyDown (KeyCode.W) && canJump) {
            jump ();
            // animator.SetBool ("Jump", true);
            IsGround = false;
            canJump = false;
            // animator.SetBool ("DoubleJump", false);
        }

    }
    // 跳跃动作
    public void jump () {
        player.velocity = Vector2.up * jumpForce;
    }
    public void changeHealth (int amount) {
        //可能是受到伤害，也可能是加血
        if (amount < 0) {
            // 如果是受伤， 设置无敌状态， 则2秒内不能受伤
            if (isInvincible == true) {
                return;
            }
            isInvincible = true;
            //播放受伤动画
            // anim.SetTrigger ("Hit");
            // //播放受伤音效
            // AudioManager.instance.AudioPlay (hitClip);
            //为无敌计时器赋值
            invincibleTimer = invincibleTime;
        }
        //更改健康值
        currentHealth = Mathf.Clamp (currentHealth + amount, 0, maxHealth);
        // 更新血条
        UIManager.instance.UpdateHealthBar (currentHealth, maxHealth);
        //调试
        Debug.Log (currentHealth + "/" + maxHealth);
    }

    public void OnCollisionEnter2D (Collision2D coll) {
        if (coll.gameObject.tag == "Road") {
            canJump = true;
            IsGround = true;
        }
    }
}