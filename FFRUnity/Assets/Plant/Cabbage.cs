using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabbage : Seed
{
    public override void Setup()
    {
        base.Setup();
        curSeed = this;
        SetUpTasks(1);
        SetUpTasks(2);
        SetUpTasks(3);
    }
}
