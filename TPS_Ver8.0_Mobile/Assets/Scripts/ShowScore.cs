using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text scoreText;
    public string colorText;
    private void Start()
    {
        colorText = GameObject.Find("ForRanking").GetComponent<ForRanking>().score.ToString();
        scoreText.text = "SCORE: "+"<color=#FFE146>" + colorText + "</color>";
    }
}
