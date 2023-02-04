using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Seed
{
    private float score;
    private List<int> tasks;

    public Seed prevSeed;
    public Seed curSeed;

    public virtual void Setup() { }

    public Seed GetSeed()
    {
        return curSeed;
    }

    public Seed GetLastSeed()
    {
        return prevSeed;
    }

    public void SetUpTasks(int newTasks)
    {
        tasks.Add(newTasks);
    }
}
