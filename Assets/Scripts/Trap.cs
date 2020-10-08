using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter2D (Collider2D other) {
        PlayerControllor pc = other.GetComponent<PlayerControllor> ();
        if (pc != null) {
            if (pc.MyCurrentHealth > 0) {
                pc.changeHealth (-1);
            }
            Debug.Log ("玩家碰到了陷阱！");
        }
    }
}