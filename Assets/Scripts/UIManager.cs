using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    // Start is called before the first frame update

    public Slider hpSlider;

    public Slider bossHpSlider;

    public Slider progressSlider;

    public GameObject backGround;

    public Text scoreText;
    public static UIManager instance { get; private set; }

    private void Awake () {
        instance = this;
    }
    void Start () {

    }

    public void UpdateHealthBar (int curAmount, int maxAmount) {
        // healthBar.fillAmount = (float) curAmount / (float) maxAmount;
        hpSlider.value = (float) curAmount / (float) maxAmount;
    }

    public void UpdateBossHealthBar (int curAmount, int maxAmount) {
        bossHpSlider.value = (float) curAmount / (float) maxAmount;
    }

    public void UpdateScore (int score) {
        score = int.Parse (scoreText.text) + score;
        scoreText.text = score.ToString ();
    }

    public void UpdateProgress (float curPostion) {
        progressSlider.value = curPostion / (backGround.transform.position.x * 2);
    }
}