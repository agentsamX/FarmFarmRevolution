using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoPickupStation : SeedPickupStation
{

    public GameObject seedVisualPrefab;

   public override string GetHintText()
    {
        return "Press E to pick up Tomato";
    }

    public override void GivePlayerSeed(GameObject player)
    {
        Vector3 pos = player.transform.position;
        pos.z -= 0.1f;
        GameObject Visual = Instantiate(seedVisualPrefab, pos, Quaternion.identity, player.transform); //create visual
        Visual.tag = "PickedupPlant";
        player.GetComponent<PlayerController>().SetCurrentSeed(new Tomato());
    }
}
