using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject enemy;
    private int randInt;
    private float rand;
    private float rand2;
    private float roomRangePos;
    private float roomRangeNeg;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++){
            //get a random number
            randInt = Random.Range(0,100);
            Debug.Log("MobSpawner rand = " + rand);

            if (randInt < 75){
                //set the spawn location in the room
                roomRangeNeg = -15.0f;
                roomRangePos = 15.0f;

                //roll random number for position in room
                rand = Random.Range(roomRangeNeg,roomRangePos);
                rand2 = Random.Range(roomRangeNeg,roomRangePos);

                //offset position to be relative to the room's location
                rand = rand + transform.position.x;
                rand2 = rand2 + transform.position.z;

                //set position of the spawn
                position = new Vector3(rand,-2.49f,rand2);

                //spawnt the enemy
                Instantiate(enemy, position, Quaternion.Euler(new Vector3(0,180,0)));
            }
        }
    }
}
