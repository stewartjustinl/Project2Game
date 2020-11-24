using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDetectorEnemy : MonoBehaviour
{
    public int health;
    public int EnemyDropChance;
    public int PowerupChoice;
    public Vector3 position;
    public GameObject teleporter;
    public GameObject Powerup;
    public GameObject Food;
    public System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) {
            
            EnemyDropChance = rand.Next(0,101);
            PowerupChoice = rand.Next(0,2);
            
            //get the position to spawn an item or something
            position = transform.position;

            //remove the enemy
    		Destroy(gameObject);

            Debug.Log("EnemyDropChance = " + EnemyDropChance);
            Debug.Log("PowerupChoice = " + PowerupChoice);

            if (EnemyDropChance <= 26 )
            {
                Debug.Log("Spawning Food");
                Instantiate(Food, position, Quaternion.identity);
            }
            
            if ((EnemyDropChance > 26) && ( EnemyDropChance <= 51 ) )
            {
                Debug.Log("Spawning Powerup");
                Instantiate(Powerup, position, Quaternion.identity);
            }
            if ((EnemyDropChance > 52) && ( EnemyDropChance <= 76 ) )
            {
                Debug.Log("Nothing Spawned, EnemyDropChance 52-76");
            }
            if ((EnemyDropChance > 77) && ( EnemyDropChance <= 101 ) )
            {
                Debug.Log("Nothing Spawned, EnemyDropChance 77-101");
            }
            
            //if the enemy is a boss, spawn teleporter to next level
            if (gameObject.name == "Boss Enemy")
            {
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
        Debug.Log ("Updated Health: " + health);
    }
}
