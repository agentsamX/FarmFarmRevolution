using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPickupStation : MonoBehaviour
{
    public static string HintText;
    
    public string GetHintText()
    {
        return HintText;
    }
    public virtual void GivePlayerSeed(GameObject player)
    {}

}
