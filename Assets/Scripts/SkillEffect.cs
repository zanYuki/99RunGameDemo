using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillEffect : MonoBehaviour
{

    float currTime;

    Image img;

    Sprite sprite;

    Color transparant;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        sprite = img.sprite;
        transparant = new Color(0, 0, 0, 0);
    }

    private void OnEnable()
    {
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currTime = currTime + Time.deltaTime;
        if(currTime > 0.1) {
            img.sprite = null;
            img.color = transparant;
        }
        if(currTime > 0.2) {
            img.sprite = sprite;
            img.color = Color.white;
        }
        if(currTime > 0.3) {
            img.sprite = null;
            img.color = transparant;
        }
        if(currTime > 0.4) {
            img.sprite = sprite;
            img.color = Color.white;
        }
        if(currTime > 1) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
            for (int i = 0; i < enemies.Length; ++i) {
                Destroy(enemies[i]);
                UIManager.instance.UpdateScore(10);
            }
            gameObject.SetActive(false);
        }
    }
}
