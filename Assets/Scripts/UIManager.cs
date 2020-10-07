using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    // Start is called before the first frame update

    public Image healthBar;
    public Slider hpSlider;
    public static UIManager instance { get; private set; }
    void Start () {
        instance = this;
    }

    public void UpdateHealthBar (int curAmount, int maxAmount) {
        healthBar.fillAmount = (float) curAmount / (float) maxAmount;
        hpSlider.value = (float) curAmount / (float) maxAmount;
    }
}