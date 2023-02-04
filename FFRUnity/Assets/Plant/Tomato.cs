using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Tomato : Seed
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
