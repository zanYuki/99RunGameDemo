using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMove : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(speed > 0)
            gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
