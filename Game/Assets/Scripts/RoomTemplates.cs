using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] items;
    public GameObject boss;
    public bool bossSpawned;

    public GameObject closedRoom;
    public GameObject doubleSpawn;
    public List<GameObject> roomsList;
    public int roomCount = 10;

    public int count;
    public float waitTime;
    public bool nextLevelSpawned;
    public GameObject nextLevel;
    private Vector3 spawnPosition;

    void Update(){
        if (waitTime <= 0 && bossSpawned == false){
            //once wait is over, spawn boss in last room
            //make a vector for instantiation
            float x = roomsList[roomsList.Count - 1].transform.position.x;
            float y = -2;
            float z = roomsList[roomsList.Count - 1].transform.position.z;

            //set vector for spawn position of boss
            spawnPosition = new Vector3(x,y,z);

            //instantiate the boss enemy game object
            Instantiate(boss, spawnPosition, Quaternion.identity);
            Debug.Log("Boss Spawned");
<<<<<<< HEAD
            bossSpawned = true;
=======
            nextLevelSpawned = true;
>>>>>>> e12b05fc489b9decfad7bb6cee2de44e8dc17599

        } else {
            //decrement wait time
            waitTime -= Time.deltaTime;
        }
    }
}
