using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurt : MonoBehaviour
{
    private GameObject boss;
    private GameObject player;
    private PigBoss pb;
    // private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindWithTag("Boss");
        player = GameObject.FindWithTag("Hero");
        pb = boss.GetComponent<PigBoss>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
        if (playerAttack != null)
        {
            Debug.Log("玩家对boss造成了伤害！");
            pb.changeHealth(-1);
        }

    }


}
