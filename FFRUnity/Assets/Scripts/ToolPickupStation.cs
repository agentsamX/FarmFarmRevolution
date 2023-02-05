using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickupStation : MonoBehaviour
{
    public string Name;
    public bool isWatering;
    public bool isTilling;
    public bool isFertilizer;

    private void Start() 
    {
        if (isWatering) Name = "Press E To pickup Watering Can";
        else if (isTilling) Name = "Press E to pickup Till";
        else if (isFertilizer) Name = "Press e to pickup Fertilizer";
    }

    public void GiveTool(PlayerController thisPlayer)
    {
        if (isWatering)
        {
            thisPlayer.currentTool = Tasks.Water;
        }
        else
         if (isTilling)
        {
            thisPlayer.currentTool = Tasks.Till;
        }
        else
         if (isFertilizer)
        {
            thisPlayer.currentTool = Tasks.Fertilize;
        }
    }

}
