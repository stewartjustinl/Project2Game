using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemMaker : MonoBehaviour
{
    public int count = 0;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //vectorTest = new Vector3(transform.position.x, 0, transform.position.z);
            //rand = Random.Range(0,2);
            //Instantiate(templates.items[rand], vectorTest, Quaternion.identity);
            Debug.Log("collided");
            SceneManager.LoadScene(1);
            count++;
        }
    }
}
