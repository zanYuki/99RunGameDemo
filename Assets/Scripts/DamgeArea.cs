﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeArea : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnTriggerStay2D (Collider2D other) {
        PlayerControllor pc = other.GetComponent<PlayerControllor> ();
        if (pc != null) {
            pc.changeHealth (-1);
        }
    }
}