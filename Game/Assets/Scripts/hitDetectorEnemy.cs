using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDetectorEnemy : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) {
    		Destroy(gameObject);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
    	if(other.tag == "Projectile")
    	{
    		Debug.Log ("Collision");
    		health = health - 1;
    	}
    }
}
