using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabbage : Seed
{
    public Cabbage()
    {
        SetUpTasks(Tasks.Till);
        SetUpTasks(Tasks.Water);
        SetUpTasks(Tasks.Fertilize);
        SetScore(300);
    }
}
