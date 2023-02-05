using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickupStation : MonoBehaviour
{
    public bool isWatering;
    public bool isTilling;
    public bool isFertilizer;

    public string GetToolHint()
    {
      //  return 
        if (isWatering) return "Pick up Watering Can";
          if (isTilling) return "Pick up Till";
            if (isFertilizer) return "Pick up Fertilizer";

        return "Pick up tool";
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
