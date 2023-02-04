using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPickupStation : MonoBehaviour
{
    public GameObject PotatoSeedPrefab;

    public void GivePlayerSeed(GameObject player)
    {
        Vector3 pos = player.transform.position;
        pos.z -= 0.1f;
        Instantiate(PotatoSeedPrefab, pos, Quaternion.identity, player.transform); //create visual
        player.GetComponent<PlayerController>().SetCurrentSeed(new Tomato());
    }
}
