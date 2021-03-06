﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int health;
    public int EnemyDropChance;
    public int PowerupChoice;
    public Vector3 position;
    public GameObject teleporter;
    public GameObject Powerup;
    public GameObject Food;
    public System.Random rand = new System.Random();
    
    [SerializeField]
    Transform player;

    private float distanceToEnemy;
    private bool inRange;
    private Vector3 targetVector;

    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        //initialize the health
        health = 3;
        
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.Log("Nav mesh agent component is not attatched to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //when character dies
        if (health <= 0) {
            //set the drop rates
            EnemyDropChance = rand.Next(0,101);
            PowerupChoice = rand.Next(0,2);
            
            //get the position to spawn an item or something
            position = transform.position;

            //remove the enemy
    		Destroy(gameObject);

            //log what the drop chancce was
            Debug.Log("EnemyDropChance = " + EnemyDropChance);
            Debug.Log("PowerupChoice = " + PowerupChoice);

            if (EnemyDropChance <= 26 )
            {
                //spawn item at desired drop rate
                Debug.Log("Spawning Food");
                Instantiate(Food, position, Quaternion.identity);
            }
            
            if ((EnemyDropChance > 26) && ( EnemyDropChance <= 51 ) )
            {
                //spawn item at desired drop rate
                Debug.Log("Spawning Powerup");
                Instantiate(Powerup, position, Quaternion.identity);
            }
            if ((EnemyDropChance > 52) && ( EnemyDropChance <= 76 ) )
            {
                //log that the drop didn't spawn, and what the rate was
                Debug.Log("Nothing Spawned, EnemyDropChance 52-76");
            }
            if ((EnemyDropChance > 77) && ( EnemyDropChance <= 101 ) )
            {
                //log that the drop didn't spawn, and what the rate was
                Debug.Log("Nothing Spawned, EnemyDropChance 77-101");
            }
            
            //if the enemy is a boss, spawn teleporter to next level
            if (gameObject.name == "Boss Enemy")
            {
                Debug.Log("Spawning teleporter");
                //spawn the teleporter at the boss enemies location
                Instantiate(teleporter, position, Quaternion.identity);
            }
        }
       SetDestination();
    }
    
    void OnTriggerEnter(Collider other)
    {
        //need to change this so player isnt damaged by own projectiles
    	if(other.tag == "Projectile")
    	{
    		Debug.Log ("Collision");
            Destroy(other.gameObject);
    		health = health - 1;
    	}
        Debug.Log ("Updated Health: " + health);
        if(other.tag == "Player")
        {
            //do something
        }
    }
    
    private void SetDestination()
    {
        //get the target vector position
        //Vector3 targetVector = player.transform.position;
        targetVector = Vector3.Lerp(player.transform.position, transform.position, 0.5f);

        if (player.transform.position == null)
        {
            Debug.Log("Could not get " + player.gameObject.tag);
        }
        if (true){
            if (distanceToEnemy < 0){
                _navMeshAgent.SetDestination(targetVector);
                _navMeshAgent.updateRotation = false;
                //transform.rotation = Quaternion.LookRotation(_navMeshAgent.velocity.normalized);
            }
            else {
                _navMeshAgent.SetDestination(targetVector);
                _navMeshAgent.updateRotation = false;
                //transform.rotation = Quaternion.LookRotation(_navMeshAgent.velocity.normalized);
            }
        }
    }
}
