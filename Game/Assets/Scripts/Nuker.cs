using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuker : MonoBehaviour
{
    //script to delete empty room that spawns at start
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Block")) {
            Destroy(other.gameObject);
        }
    }
}
