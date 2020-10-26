using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private GameObject player;
    // private float speed = 1f;

    // Start is called before the first frame update
    void Start () {
        player = GameObject.FindWithTag ("Hero");
    }

    // Update is called once per frame
    void Update () {
        // 跟踪主角
        // Vector2 v = player.transform.position;
        // // Debug.Log (v);
        // transform.Translate (v * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D (Collider2D other) {
        PlayerControllor pc = other.GetComponent<PlayerControllor> ();
        if (pc != null) {
            if (pc.MyCurrentHealth > 0) {
                pc.changeHealth (-1);
            }
            Destroy (this.gameObject);
            // UIManager.instance.UpdateScore (10);
            Debug.Log ("玩家碰到了敌人！");
        }
    }
}