using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    Tomato curSeed;
    public GameObject farmplot;
    void Start()
    {
        curSeed = new Tomato();
        farmplot.GetComponent<FarmPlot>().SetSeed(curSeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
