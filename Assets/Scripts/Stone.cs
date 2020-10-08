using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter2D (Collider2D other) {
        PlayerControllor pc = other.GetComponent<PlayerControllor> ();
        if (pc != null) {
            Destroy (this.gameObject);
            Debug.Log ("玩家碰到了五彩石！");
        }
    }
}