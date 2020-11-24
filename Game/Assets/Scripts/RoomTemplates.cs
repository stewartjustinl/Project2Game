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

    public GameObject closedRoom;
    public List<GameObject> roomsList;

    public int count;
    public float waitTime;
    public bool nextLevelSpawned;
    public GameObject nextLevel;
    private Vector3 spawnPosition;

    void Update(){
        if (waitTime <= 0 && nextLevelSpawned == false){
            //once wait is over, spawn boss in last room

            //make a vector for instantiation
            float x = roomsList[roomsList.Count - 1].transform.position.x;
            float y = -2;
            float z = roomsList[roomsList.Count - 1].transform.position.z;
            spawnPosition = new Vector3(x,y,z);
            Instantiate(boss, spawnPosition, Quaternion.identity);
            Debug.Log("Boss Spawned");
            nextLevelSpawned = true;
        } else {
            waitTime -= Time.deltaTime;
        }
    }
}
