using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text timeText;
    public int startTime;
    private int addedTime;
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "Time : " + startTime;
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int time = startTime - (int)Time.timeSinceLevelLoad + addedTime;
        timeText.text = "Time : " + time;
        if (time <= 0)
        {
            PlayerPrefs.SetInt("LastScore", score);
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void AddScore(int addAmount)
    {
        score+=addAmount;
        scoreText.text = "Score : " + score;
    }

    void AddTime(int addAmount)
    {
        addedTime += addAmount;
    }
}
