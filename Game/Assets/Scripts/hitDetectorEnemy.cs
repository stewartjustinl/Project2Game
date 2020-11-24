using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDetectorEnemy : MonoBehaviour
{
    public int health;
    public Vector3 position;
    public GameObject teleporter;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) {
            //get the position to spawn an item or something
            position = transform.position;

            //remove the enemy
    		Destroy(gameObject);

            //if the enemy is a boss, spawn teleporter to next level
            if (gameObject.name == "Boss Enemy"){
                Debug.Log("Spawning teleporter");
                Instantiate(teleporter, position, Quaternion.identity);
            }
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
    	if(other.tag == "Projectile")
    	{
    		Debug.Log ("Collision");
            Destroy(other.gameObject);
    		health = health - 1;
    	}
    }
}
