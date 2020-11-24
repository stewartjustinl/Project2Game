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
                roomRangeNeg = -40.0f;
                roomRangePos = 40.0f;
                rand = Random.Range(roomRangeNeg,roomRangePos);
                rand2 = Random.Range(roomRangeNeg,roomRangePos);
                position = new Vector3(rand,0,rand2);

                //spawnt the enemy
                Instantiate(enemy, position, Quaternion.Euler(new Vector3(0,0,180)));
            }
        }
    }
}
