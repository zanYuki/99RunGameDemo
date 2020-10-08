using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillClick : MonoBehaviour {
    Button skillButton;

    public Text scoreText;
    // Start is called before the first frame update
    void Start () {
        skillButton = GetComponent<Button> ();
        skillButton.interactable = false;
    }

    // Update is called once per frame
    void Update () {
        if (int.Parse (scoreText.text) >= 100) {
            skillButton.interactable = true;
        }
    }

    public void Click () {
        Debug.Log ("SkillClick");
    }
}