using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    public Seed prevSeed;
    public Seed curSeed;

    public SpriteRenderer xMark;
    public SpriteRenderer check;
    public SpriteRenderer fert;
    public SpriteRenderer till;
    public SpriteRenderer water;
    public SpriteRenderer task;

    private void Update()
    {
        curSeed = new Tomato();
        Debug.Log(curSeed);
        switch (curSeed.GetTasks())
        {
            case Seed.Tasks.Water:
                water.enabled = true;
                break;
                case Seed.Tasks.Fertilize:
                fert.enabled = true;
                break;
                case Seed.Tasks.Till: 
                till.enabled = true;
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
