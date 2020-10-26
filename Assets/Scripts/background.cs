﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{

    public Camera camera;

    bool newBgCreated;

    Vector2 camPos;
    // Start is called before the first frame update
    void Start()
    {
        newBgCreated = false;
    }

    // Update is called once per frame
    void Update()
    {
        camPos = camera.transform.position;
        if (!newBgCreated && camPos.x - transform.position.x > 36.5 - 9) {
            GameObject newBg = Instantiate(this.gameObject, new Vector2(transform.position.x + 73f, transform.position.y), Quaternion.identity);
            newBgCreated = true;
        }

        if (camPos.x - transform.position.x > 36.5 + 9) {
            Destroy(this.gameObject);
        }
    }
}
