using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game singleton;
    [SerializeField]
    RobotSpawn[] spawns;
    public int enemiesLeft;
    // Start is called before the first frame update
   
    // Initialize Singleton / Spawn Robots
    void Start()
    {
        singleton = this;
        SpawnRobots();
    }
    // Goes through each robot in the array and spawns them
    private void SpawnRobots()
    {
        foreach (RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();
            enemiesLeft++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
