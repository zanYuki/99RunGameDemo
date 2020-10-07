using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {
    // public ParticleSystem collectEffect;

    // public AudioClip collectClip;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter2D (Collider2D other) {
        PlayerControllor pc = other.GetComponent<PlayerControllor> ();
        if (pc != null) {
            if (pc.MyCurrentHealth < pc.MyMaxHealth) {
                pc.changeHealth (1);
                // Instantiate (collectEffect, transform.position, Quaternion.identity);
                // AudioManager.instance.AudioPlay (collectClip);
                Destroy (this.gameObject);

            }
            Debug.Log ("玩家碰到了草莓！");
        }
    }

}