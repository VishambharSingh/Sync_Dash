using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    Camera mainCamera;
    float initialZPos;
    // Start is called before the first frame update
    void Start()
    {
        initialZPos = transform.position.z; 
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       if(mainCamera.transform.position.z > transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + initialZPos);
        }
    }

   
}
