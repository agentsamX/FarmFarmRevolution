using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornPickupStation : SeedPickupStation
{
      public string HintText = "Press E to pickup Corn";
    public GameObject seedVisualPrefab;

    public override void GivePlayerSeed(GameObject player)
    {
        Vector3 pos = player.transform.position;
        pos.z -= 0.1f;
      //  Instantiate(seedVisualPrefab, pos, Quaternion.identity, player.transform); //create visual
        player.GetComponent<PlayerController>().SetCurrentSeed(new Corn());
    }
}
