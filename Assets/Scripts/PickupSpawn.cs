using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pickups;

    // Instantiates random pickup
    void spawnPickup()
    {
        // Instantiate a random pickup
        GameObject pickup = Instantiate(pickups[Random.Range(0,
       pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;
    }
    // Wait 20 seconds before spawning
    IEnumerator respawnPickup()
    {
        yield return new WaitForSeconds(20);
        spawnPickup();
    }
    // Spawns pickup when game begins
    void Start()
    {
        spawnPickup();
    }
    // Starts coroutine to respawn when picked up
    public void PickupWasPickedUp()
    {
        StartCoroutine("respawnPickup");
    }
}
