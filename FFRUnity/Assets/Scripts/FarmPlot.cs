using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    public Seed prevSeed;
    public Seed curSeed;
    private ParticleSystem particle;

    public SpriteRenderer xMark;
    public SpriteRenderer check;
    public SpriteRenderer fert;
    public SpriteRenderer till;
    public SpriteRenderer water;
    public SpriteRenderer task;


    private void Awake()
    {
        particle= GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (curSeed != null)
        {
            switch (curSeed.GetTasks())
            {
                case Tasks.Water:
                    water.enabled = true;
                    ResetSprites();
                    break;
                case Tasks.Fertilize:
                    fert.enabled = true;
                    ResetSprites();
                    break;
                case Tasks.Till:
                    till.enabled = true;
                    ResetSprites();
                    break;
            }
            if (curSeed.tasksToDo.Count.Equals(null))
            {
                ResetSprites();
                curSeed = null;
            }
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
        particle.Play();
    }

    private void ResetSprites()
    {
        switch (curSeed.GetTasks())
        {
            case Tasks.Water:
                fert.enabled = false;
                till.enabled = false;
                break;
                case Tasks.Fertilize : 
                water.enabled = false;
                till.enabled = false;
                break;
                case Tasks.Till:
                water.enabled = false;
                fert.enabled = false;
                break;
            default:
                water.enabled = false;
                fert.enabled = false;
                till.enabled = false;
                task.enabled = false;
                break;
        }
        if (curSeed.tasksToDo.Count.Equals(null))
        {
            water.enabled = false;
            fert.enabled = false;
            till.enabled = false;
            task.enabled = false;
        }
    }

    public void DoTasks()
    {
        curSeed.CompleteTask();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!curSeed.tasksToDo.Count.Equals(null) && curSeed != null)
            {
                if (collision.gameObject.GetComponent<PlayerController>().currentTool != curSeed.GetTasks())
                {
                    xMark.enabled = true;
                }
                else if (collision.gameObject.GetComponent<PlayerController>().currentTool == curSeed.GetTasks())
                {
                    check.enabled = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            xMark.enabled = false;
            check.enabled = false;
        }
    }
}
