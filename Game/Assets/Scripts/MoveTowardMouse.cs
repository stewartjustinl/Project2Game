﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardMouse : MonoBehaviour
{
    public Vector3 target;
    public float speed = 20.0f;
    public float projectileOffset;

    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
        transform.Translate(Vector3.forward * projectileOffset); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + target * speed * Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
