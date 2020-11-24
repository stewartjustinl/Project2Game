using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAdder : MonoBehaviour
{
    private RoomTemplates templates;
    //add spawned room to list of rooms
    void Start(){
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.roomsList.Add(this.gameObject);
    }
}
