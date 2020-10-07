using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JumpClick : MonoBehaviour {

    Button jumpButton;
    // 开始时按钮不可用，待收集5个后可用
    public PlayerControllor player;
    private bool isInteractable;
    // Start is called before the first frame update
    void Start () {
        jumpButton = GetComponent<Button> ();
        jumpButton.interactable = false;
    }

    // Update is called once per frame
    void Update () {
        if (player.MyCurrentHealth == player.MyMaxHealth) {
            jumpButton.interactable = true;
        }
    }

    public void Click () {
        Debug.Log ("JUMP");
    }
}