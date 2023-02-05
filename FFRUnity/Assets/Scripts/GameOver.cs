using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject NewHighScore;
    public TMP_Text text;
    public float timer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score : " + PlayerPrefs.GetInt("LastScore");
        if(PlayerPrefs.GetInt("LastScore")>PlayerPrefs.GetInt("BestScore",0))
        {
            PlayerPrefs.SetInt("BestScore", PlayerPrefs.GetInt("LastScore"));
            NewHighScore.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad>timer)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
