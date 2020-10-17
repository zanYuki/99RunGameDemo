using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


public class PigBoss : MonoBehaviour {
    public GameObject player;

    Vector2 palyerVector;

    //最大健康值
    private int maxHealth = 1000;
    //当前健康值
    private int currentHealth;
    //其他脚本可获取最大健康值

    // 判断是否开始行动
    private bool isMove;
    // 初始速度
    public float speed;
    // 获取对象
    private PlayerControllor pc;
    // Start is called before the first frame update
    void Start () {
        pc = player.GetComponent<PlayerControllor> ();
        speed = pc.speed;
        currentHealth = maxHealth;
        UIManager.instance.UpdateBossHealthBar(currentHealth,maxHealth);
    }

    // Update is called once per frame
    void Update () {
        if (isMove) {
            // 如果在视野内则开始 ， 发射小怪 以相同的速度移动，达到相对静止
            transform.Translate (Vector2.right * Time.deltaTime * speed);
            // Boss 攻击模式 召唤小怪，主角攻击小怪，boss掉血可按音乐节奏
            // ObjectFactory.CreateGameObject("Camera");
            // Selection.activeGameObject = ObjectFactory.CreateGameObject("Camera", typeof(Camera));
        }
    }
    // 在玩家视野内 直到完全显示才同步移动
    void OnBecameVisible () {
        isMove = true;
        Debug.Log ("isview");

    }

    private void OnBecameInvisible () {
        Debug.Log ("noview");
        isMove = false;
    }

    private void summonFish(){

    }
}