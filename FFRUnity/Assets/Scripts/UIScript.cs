using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text timeText;
    public int startTime;
    private int addedTime;
    private float score = 0;


    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "Time : " + startTime;
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeText.text = "Time : " + (startTime - (int)Time.timeSinceLevelLoad + addedTime);
    }

    public void AddScore(float addAmount)
    {
        score+=addAmount;
        scoreText.text = "Score : " + score;
    }

    public void AddTime(int addAmount)
    {
        addedTime += addAmount;
    }

    public float GetScore() 
    {
        return score;
    }
}
