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
    public Stack<Tasks> tasksToDo = new Stack<Tasks>();

    public void SetUpTasks(Tasks newTasks)
    {
        tasksToDo.Push(newTasks);
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
        return tasksToDo.Peek();
    }

    public void CompleteTask()
    {
        tasksToDo.Pop();
    }
}
