using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForRanking : MonoBehaviour
{
    public int score;
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void getScore()
    {
        score = UIManager.Instance.getScore();
    }
}
