using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickupStation : MonoBehaviour
{
    public bool isWatering;
    public bool isTilling;
    public bool isFertilizer;

    public void GiveTool(PlayerController thisPlayer)
    {
        if (isWatering)
        {
            thisPlayer.currentTool = new Watering();
        }
        else
         if (isTilling)
        {
            thisPlayer.currentTool = new Till();
        }
        else
         if (isFertilizer)
        {
            thisPlayer.currentTool = new Fertilizer();
        }
    }

}
