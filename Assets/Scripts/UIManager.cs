using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    // Start is called before the first frame update

    public Slider hpSlider;

    public Slider bossHpSlider;

    public Slider progressSlider;

    public GameObject backGround;

    public GameObject BossHealthFrame;

    public Text scoreText;
    public static UIManager instance { get; private set; }

    public AudioSource audioSource;
    private void Awake () {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        play_stop_music();
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
        Vector2 end =  backGround.GetComponent<PolygonCollider2D>().points[1];
        progressSlider.value = curPostion / (end.x);
        if(progressSlider.value>0.95){
             SceneManager.LoadScene("overScence");
             pause_music();
        }
    }

    public void SetBossHealthBarActive(bool isActive){
        BossHealthFrame.SetActive(isActive);
    }


    //开始、停止播放
    public void play_stop_music()
    {
        Debug.Log("s");
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
    //暂停播放
    public void pause_music()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
    //改变音量
    public void change_volume(float volume)
    {
        audioSource.volume = volume;
    }
}