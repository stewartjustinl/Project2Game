using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTexture : MonoBehaviour
{
    public Material[] materials;
    private Renderer rend;
    public int rand;
    void Start()
    {
        //generate random number for materials array
        rand = Random.Range(0, materials.Length);

        rend = GetComponent<Renderer>();
        rend.enabled = true;

        //set material of the renderer
        rend.sharedMaterial = materials[rand];
    }

}
