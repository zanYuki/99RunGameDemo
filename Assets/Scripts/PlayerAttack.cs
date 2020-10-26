using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    float attackTime;

    float currTime;
    // Start is called before the first frame update
    void Start()
    {
        attackTime = 0.2f;
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf) {
            currTime = currTime + Time.deltaTime;
        }
        if (currTime > attackTime) {
            gameObject.SetActive(false);
            currTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster") {
            UIManager.instance.UpdateScore(10);
            Destroy(other.gameObject);
            Debug.Log("attack hit");
        }
    }
}
