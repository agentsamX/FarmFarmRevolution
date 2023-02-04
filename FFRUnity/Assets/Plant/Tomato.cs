using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Tomato : Seed
{
    public Tomato()
    {
        SetUpTasks(Tasks.Water);
        SetScore(100);
    }
}
