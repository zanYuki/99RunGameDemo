using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillImg : MonoBehaviour
{
    float existTime;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        existTime = 1f;
    }

    private void OnEnable()
    {
        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
        if (gameObject.activeSelf)
        {
            if (Time.realtimeSinceStartup - startTime > existTime)
            {
                Time.timeScale = 1;
                gameObject.SetActive(false);
            }
        }

    }
}
