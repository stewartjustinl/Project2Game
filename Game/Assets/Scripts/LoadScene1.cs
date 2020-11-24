using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour
{
    public int count = 0;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("collided");
            SceneManager.LoadScene(1);
        }
    }
}
