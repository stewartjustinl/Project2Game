using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    //spawn room based on needed direction
    //1 = bottom, 2 = top, 3 = left, 4 = right
    private RoomTemplates templates;
    private int rand;
    public int direction;
    private Vector3 vectorTest;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        //get access to room arrays in room templates script
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        //spawn rooms with delay
        Invoke("Spawn",0.5f);
    }

    void Spawn()
    {
        if (spawned == false) {
            vectorTest = new Vector3(transform.position.x, 0, transform.position.z);
            switch (direction)
            {
                case 1:
                    //get random number for room selection
                    rand = Random.Range(0,templates.bottomRooms.Length);
                    //spawn room with bottom door
                    Instantiate(templates.bottomRooms[rand], vectorTest, Quaternion.identity);
                    break;
                case 2:
                    //get random number for room selection
                    rand = Random.Range(0,templates.topRooms.Length);
                    //spawn room with top door
                    Instantiate(templates.topRooms[rand], vectorTest, Quaternion.identity);
                    break;
                case 3:
                    //get random number for room selection
                    rand = Random.Range(0,templates.leftRooms.Length);
                    //spawn room with left door
                    Instantiate(templates.leftRooms[rand], vectorTest, Quaternion.identity);
                    break;
                case 4:
                    //get random number for room selection
                    rand = Random.Range(0,templates.rightRooms.Length);
                    //spawn room with right door
                    Instantiate(templates.rightRooms[rand], vectorTest, Quaternion.identity);
                    break;
                default:
                    break;
            }
            Debug.Log("Spawn set to true");
            spawned = true;
        }
    }
    void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        Debug.Log("Spawn Point Destroyed");
    }
}
