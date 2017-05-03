﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowardsPlayer : MonoBehaviour {

    public Transform target;
    public float speed = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 dir = target.position - transform.position;

       
        dir.Normalize();

       
        Debug.Log("Facing? " + transform.forward);

      
        Debug.Log("Dir: " + dir);

        //confirm the magnitude of the dir is 1 after it's normalized (spoiler alert: it is)
        Debug.Log("Normalized dir? " + dir.magnitude);

        //Get the dot product of the "forward" and the dir
        //The dot product for normalized vectors will be
        //  1 if the vectors are the same
        // -1 if the vectors are opposite
        //  0 if the vectors are perpendicular
        // >0 if there is less than 90 degrees between the vectors
        // <0 if there is greater than 90 degrees between the vectors
        if (Vector3.Dot(transform.forward, dir) > 0)
        {
            //if the target is in front of the object, draw a line
            Debug.DrawRay(transform.position, dir, Color.cyan);

            //move towards the target
            transform.position += dir * speed * Time.deltaTime;

            //rotate towards the target
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), .1f);
        }

        //Draw a ray coming out of the front of the object
        Debug.DrawRay(transform.position, transform.forward * 3, Color.black);
        //Draw a ray coming out of the top of the object
        Debug.DrawRay(transform.position, transform.up * 3, Color.black);

        //if "space" is pressed
   
    }
}
