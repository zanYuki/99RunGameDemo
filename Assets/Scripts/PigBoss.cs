using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


public class PigBoss : MonoBehaviour
{
    public GameObject player;

    Vector2 palyerVector;

    //最大健康值
    private int maxHealth = 20;
    //当前健康值
    private int currentHealth;
    //其他脚本可获取最大健康值

    // 判断是否开始行动
    private bool isMove;
    // 初始速度
    public float speed;
    // 获取对象
    private PlayerControllor pc;
    // 攻击物体
    public GameObject attackFish;

    public float attackTimer; // 攻击计时器

    public float attackTime = 1; // 攻击计时器

    private bool isAttack; // 是否可攻击

    private ArrayList fishList;
    private Animator animator;

    private AudioSource audioSource;

    private bool isShout;

    public GameObject fireEntity;
    // Start is called before the first frame update
    void Start()
    {
        pc = player.GetComponent<PlayerControllor>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        isShout = false;
        isAttack = true;
        isMove = false;
        attackTimer = attackTime;
        fishList = new ArrayList();
        speed = pc.speed;
        currentHealth = maxHealth;
        UIManager.instance.UpdateBossHealthBar(currentHealth, maxHealth);
        UIManager.instance.SetBossHealthBarActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            animator.SetTrigger("fly");
            // 如果在视野内则开始 ， 发射小怪 以相同的速度移动，达到相对静止
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            // Boss 攻击模式 召唤小怪，主角攻击小怪，boss掉血可按音乐节奏
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                summonFish();
                attackTimer = attackTime;
            }
        }
        else
        {
            float offest = transform.position.x - player.transform.position.x;
            if (offest <= 7)
            {
                if(!isShout) {
                    audioSource.Play();
                    isShout = true;
                }
                isMove = true;
                UIManager.instance.SetBossHealthBarActive(true);
                Debug.Log("isMove : "+isMove + "offest : "+offest);
                animator.SetTrigger("PigJump");
            }
        }
    }
    // 在玩家视野内 直到完全显示才同步移动
    void OnBecameVisible()
    {
        // isMove = true;
        // animator.SetTrigger("PigJump");
        // Debug.Log("bigboss isview");
    }

    private void OnBecameInvisible()
    {
        Debug.Log(" bigboss noview");
        isMove = false;
    }

    // 召唤小鱼
    private void summonFish()
    {
        GameObject fish = Instantiate(attackFish, new Vector2(transform.position.x, player.transform.position.y), Quaternion.identity);
        fish.transform.SetParent(fireEntity.transform,true);
        fishList.Add(fish);
    }

    public void changeHealth (int amount) {
        //更改健康值
        currentHealth = Mathf.Clamp (currentHealth + amount, 0, maxHealth);
        // 更新血条
        UIManager.instance.UpdateBossHealthBar (currentHealth, maxHealth);
        //调试
        Debug.Log (currentHealth + "/" + maxHealth);
        if (currentHealth == 0) {
            //    SceneManager.LoadScene("GameOver"); 
            Destroy (this.gameObject);
            UIManager.instance.SetBossHealthBarActive(false);
        }
    }
}