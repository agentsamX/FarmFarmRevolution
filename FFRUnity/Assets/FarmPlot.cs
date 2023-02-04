using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    public Seed prevSeed;
    public Seed curSeed;

    private void Update()
    {
        Debug.Log(curSeed);
        switch (curSeed.GetTasks())
        {
            case Seed.Tasks.Water:
                
                break;
                case Seed.Tasks.Fertilize: 
                
                break;
                case Seed.Tasks.Till: 
                
                break;
                default:
                if (curSeed == prevSeed)
                {

                }
                else
                {

                }
                break;
        }
    }

    public void SetSeed(Seed newSeed)
    {
        curSeed = newSeed;
    }
}
