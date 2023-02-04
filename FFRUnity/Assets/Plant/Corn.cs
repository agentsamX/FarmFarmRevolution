using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : Seed
{
    public Corn()
    {
        SetUpTasks(Tasks.Till);
        SetUpTasks(Tasks.Fertilize);
        SetScore(200);
    }
}
