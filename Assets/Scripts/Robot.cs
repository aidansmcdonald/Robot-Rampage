using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    GameObject missileprefab;

    [SerializeField]
    private string robotType; //colour

    public int health;      
    public int range;       //gun range
    public float fireRate;  

    public Transform missileFireSpot;   //coordinate where missiles fire
    UnityEngine.AI.NavMeshAgent agent;  //NavMesh component reference

    private Transform player;           //Robot hunts this
    private float timeLastFired;

    private bool isDead;

    public Animator robot;
    void Start()
    {
        // Sets agent and player values to their respective components
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if robot is dead
        if (isDead)
        {
            return;
        }
        // make robot face player
        transform.LookAt(player);
        // follow NavMesh to player
        agent.SetDestination(player.position);
        // Check if within range and if theres time to fire
        if (Vector3.Distance(transform.position, player.position) < range
        && Time.time - timeLastFired > fireRate)
        {
            // Update time last fired
            timeLastFired = Time.time;
            fire();
        }
    }
    private void fire()
    {
        // Creates a new missilePrefab, sets pos and rot to robots firing spot
        GameObject missile = Instantiate(missileprefab);
        missile.transform.position = missileFireSpot.transform.position;
        missile.transform.rotation = missileFireSpot.transform.rotation;
        robot.Play("Fire");
    }
}
