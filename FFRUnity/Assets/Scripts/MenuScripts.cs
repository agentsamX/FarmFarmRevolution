using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScripts : MonoBehaviour
{
    public GameObject titleText;
    public Material textMat;
    public TMP_Text HSText;
    [SerializeField]private float minPow;
    [SerializeField]private float maxPow;
    private float t;
    float dir =1;
    // Start is called before the first frame update
    void Start()
    {
        //textMat=titleText.GetComponent<Material>();
        HSText.text = "High Score : " + PlayerPrefs.GetInt("BestScore", 0);

    }

    // Update is called once per frame
    void Update()
    {
        t+=Time.deltaTime*dir;
        if(t>1.0f)
        {
            t=1.0f;
            dir=-1.0f;
        }
        else if(t<0.0f)
        {
            t=0.0f;
            dir=1.0f;
        }
        float result;
        result = Mathf.Lerp(minPow,maxPow,t);
        textMat.SetFloat("_GlowOuter",result);

        /*
        [HDR]_GlowColor			("Color", Color) = (0, 1, 0, 0.5)
        _GlowOffset			("Offset", Range(-1,1)) = 0
        _GlowInner			("Inner", Range(0,1)) = 0.05
        _GlowOuter			("Outer", Range(0,1)) = 0.05
        _GlowPower			("Falloff", Range(1, 0)) = 0.75
        */
    }

    public void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    } 

    public void ExitButton()
    {
        Application.Quit();
    }

    public void GDSAButton()
    {

    }

    public void OptionsButton()
    {

    }


}
