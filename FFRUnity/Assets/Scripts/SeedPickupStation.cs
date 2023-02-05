using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPickupStation : MonoBehaviour
{
    public static string HintText;
    
    public virtual string GetHintText()
    {
        return "";
    }

    public virtual void GivePlayerSeed(GameObject player)
    {}

}
