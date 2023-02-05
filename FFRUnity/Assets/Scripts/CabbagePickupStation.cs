using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbagePickupStation : SeedPickupStation
{
   
    // Start is called before the first frame update
   public GameObject seedVisualPrefab;


  private void Start() {
        SeedPickupStation.HintText = "Press E to pick up Cabbage";
    }

    public override void GivePlayerSeed(GameObject player)
    {
        Vector3 pos = player.transform.position;
        pos.z -= 0.1f;
      //  Instantiate(seedVisualPrefab, pos, Quaternion.identity, player.transform); //create visual
        player.GetComponent<PlayerController>().SetCurrentSeed(new Cabbage());
    }
}
