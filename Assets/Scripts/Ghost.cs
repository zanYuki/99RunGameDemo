using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
    public float speed = 2f;

    public float moveDistance = 3f;
    private bool isDown;
    // Start is called before the first frame update
    Vector2 initVector;
    void Start () {
        initVector = transform.position;
    }

    // Update is called once per frame
    void Update () {
        Vector2 v = transform.position;
        if (!isDown) {
            transform.Translate (Vector2.up * Time.deltaTime * speed);
            if (v.y > initVector.y + moveDistance) {
                isDown = true;
            }
        } else {
            transform.Translate (Vector2.down * Time.deltaTime * speed);
            if (v.y < initVector.y - moveDistance) {
                isDown = false;
            }
        }

    }
}