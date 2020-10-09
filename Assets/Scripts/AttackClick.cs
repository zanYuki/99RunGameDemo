using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackClick : MonoBehaviour {
    Button attackButton;

    public Text scoreText;
    // Start is called before the first frame update
    void Start () {
        attackButton = GetComponent<Button> ();
        attackButton.interactable = false;
    }

    // Update is called once per frame
    void Update () {
        if (int.Parse (scoreText.text) >= 100) {
            attackButton.interactable = true;
        }
    }

    public void Click () {
        Debug.Log ("AttackClick");
    }
}