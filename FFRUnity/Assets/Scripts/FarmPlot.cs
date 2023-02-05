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


    private void Awake()
    {

    }
    private void Update()
    {
        Debug.Log(curSeed);
        switch (curSeed.GetTasks())
        {
            case Seed.Tasks.Water:
                water.enabled = true;
                ResetSprites();
                break;
                case Seed.Tasks.Fertilize:
                fert.enabled = true;
                ResetSprites();
                break;
                case Seed.Tasks.Till: 
                till.enabled = true;
                ResetSprites();
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

        if (curSeed != null)
        {
            task.enabled = true;
        }
        else
        {
            task.enabled = false;
        }
    }

    public void SetSeed(Seed newSeed)
    {
        curSeed = newSeed;
    }

    private void ResetSprites()
    {
        switch (curSeed.GetTasks())
        {
            case Seed.Tasks.Water:
                fert.enabled = false;
                till.enabled = false;
                break;
                case Seed.Tasks.Fertilize : 
                water.enabled = false;
                till.enabled = false;
                break;
                case Seed.Tasks.Till:
                water.enabled = false;
                fert.enabled = false;
                break;
        }
    }

   
}
