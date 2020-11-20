using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;

    // index 0 = LR, index 1 = LRB, index 2 = LRT, index 3 = LRTB
    public GameObject[] rooms;
    public float offset;
    public int minX;
    public int maxX;
    public int minZ;
    private int direction;
    private float timeBetweenRoom;
    private float startTimeBetweenRoom = 0.25f;
    private bool stopGeneration = false;
    // Start is called before the first frame update
    void Start()
    {
        // Get random starting room for player
        int randStartingPosition = Random.Range(0, startingPositions.Length);
        Debug.Log(randStartingPosition);
        transform.position = startingPositions[randStartingPosition].position;

        // Spawn the first room
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        // Define the direction for the next room to spawn
        direction = Random.Range(1,6);
    }

    void Update()
    {
        Debug.Log("Update Called");
        if (timeBetweenRoom <= 0 && stopGeneration == false) {
            Move();
            timeBetweenRoom = startTimeBetweenRoom;
        }
        else {
            timeBetweenRoom -= Time.deltaTime;
        }
    }

    void Move()
    {
        Debug.LogFormat("Move called with direction = {0}",direction);
        // Level Generation moves right
        if (direction == 1 || direction == 2) {
            // Check if next room would spawn outside of boundry in the level
            if (transform.position.x < maxX){
                Vector3 newPosition = new Vector3
                (transform.position.x + offset, transform.position.y, transform.position.z);
                transform.position = newPosition;

                direction = Random.Range(1,6);

                // if direction moves down, spawn a top open room
                if (direction == 5)
                {
                    int rand = Random.Range(2, 4);
                    Instantiate(rooms[rand], transform.position, Quaternion.identity);
                }
                //if not down, spawn room as normal
                else
                {
                    // Spawn a room
                    int rand = Random.Range(0, rooms.Length);
                    Instantiate(rooms[rand], transform.position, Quaternion.identity);
                }

                //Make level generation continue to move left instead of right
                if (direction == 3) {
                   direction = 2; 
                }
                //Make level generation continue to move down instead of left
                else if (direction == 4) {
                   direction = 5; 
                }
            }
            // Change direction to move down instead of right
            else
            {
                direction = 5;
            }

        // Level Generation moves left
        } else if (direction == 3 || direction == 4) {
            // Check if next room would spawn outside of boundry in the level
            if (transform.position.x > minX) {
                Vector3 newPosition = new Vector3
                (transform.position.x - offset, transform.position.y, transform.position.z);
                transform.position = newPosition;

                // Spawn a room
                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                // Make level generator move right 
                direction = Random.Range(3,6);
            }
            // Change direction to move down instead of right
            else
            {
                direction = 5;
            }
        // Level Generation moves down
        } else if (direction == 5) {
            if (transform.position.z > minZ) {
                Vector3 newPosition = new Vector3
                (transform.position.x, transform.position.y, transform.position.z - offset);
                transform.position = newPosition;

                //Spawn room with top opening
                int rand = Random.Range(2,4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                
                // Make level generator move right 
                direction = Random.Range(1,6);
            }
            else
            {
                // Stop level generation.
                stopGeneration = true;
            }
        }
        
        //Debug.LogFormat("Position is: x = {0}, y = {1}, z = {2}",
        //transform.position.x,transform.position.y,transform.position.z);
    }
}