using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    public Seed currentSeed;

    private void Update()
    {
        Debug.Log(currentSeed);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSeed = new Tomato();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSeed = new Corn();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSeed = new Cabbage();
        }

        switch (currentSeed)
        {
            case Tomato:
                    break;
            case Corn:
                break;
                case Cabbage:
                break;
        }
    }
}
