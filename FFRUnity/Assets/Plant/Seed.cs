using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Seed
{
    public enum Tasks
    {
        Water,
        Till,
        Fertilize
    }

    private float score;
    private Stack<Tasks> tasks;


    public void SetUpTasks(Tasks newTasks)
    {
        tasks.Push(newTasks);
    }

    public void SetScore(float newScore)
    {
        score = newScore;
    }

    public float GetScore()
    {
        return score;
    }

    public Tasks GetTasks() 
    {
        return tasks.Peek();
    }

    public void CompleteTask()
    {
        tasks.Pop();
    }
}
