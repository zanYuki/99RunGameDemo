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

    }

    // Update is called once per frame
    void Update () {

    }

    public void Click () {
        Debug.Log ("SkillClick");
    }
}