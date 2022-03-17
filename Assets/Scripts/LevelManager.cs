using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool playerEnter, playerExit;

    //Level Spawn, Destroy
    public GameObject level;
    public GameObject destroyLevel;

    
    
    //Drone Spawn
    private bool spawned;
    public Transform[] droneSpawners;
    public GameObject drone;

    private void Awake()
    {
        playerEnter = false;
        spawned = false;
    }

    private void Update()
    {
        //Drone Spawn
        if (!spawned)
        {
            if (playerEnter)
            {
                for(int i=0; i<droneSpawners.Length; i++)
                {
                    Instantiate(drone, droneSpawners[i].position, Quaternion.identity);
                }
                
                //Level Spawn
                SpawnLevel();

                spawned = true;
            }
        }
        //Level Destroy
        if (playerExit)
        {
            if(destroyLevel != null)
            {
                Destroy(destroyLevel);
            }
        }

    }
    private void SpawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 167);
        GameObject newLevel = Instantiate(level, pos, Quaternion.identity);
        newLevel.GetComponent<LevelManager>().destroyLevel = this.gameObject;
    }
}
