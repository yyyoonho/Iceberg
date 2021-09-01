using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<UIManager>();
            return instance;
        }
    }
    public Text scoreText;
    public Slider hpSlider;

    private int score = 0;

    public void UpdateHp(int hp)
    {
        hpSlider.value = hp;
    }

    public void UpdateScoreText(int score)
    {
        this.score += score;
        scoreText.text = "SCORE:" + this.score;
    }

    public int getScore()
    {
        return this.score;
    }

}
