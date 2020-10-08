using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigBoss : MonoBehaviour {
    public GameObject player;

    Vector2 palyerVector;

    //最大健康值
    private int maxHealth = 10;
    //当前健康值
    private int currentHealth;
    //其他脚本可获取最大健康值

    // 初始速度
    public float speed = 10f;
    private bool enable = false;
    // Start is called before the first frame update
    void Start () {
        palyerVector = player.transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (enabled) {
            // 如果在视野内则开始 ， 发射小怪

        }
    }

    void OnBecameVisible () {
        enabled = true;
        // 显示血条
    }
}