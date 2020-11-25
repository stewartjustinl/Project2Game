using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportSpawner : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //check if collision was player character
        if(other.tag == "Player")
        {
            Debug.Log(other.gameObject.name + " entered the teleporter");
            //load the level scene again
            SceneManager.LoadScene(1);
        }
    }
}
