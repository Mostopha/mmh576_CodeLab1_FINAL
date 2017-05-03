using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour {

    public Transform target;
    public float speed = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get the direction vector from the current position to the target
        Vector3 dir = target.position - transform.position;

        //Draw the direction array from the current position 
        //		Debug.DrawRay(transform.position, dir, Color.magenta);

        //Normalize the dir vector
        dir.Normalize();

        //if we wanted to, we don't need to use Unity's fancy direction function
        //we can just calculate it ourselves!
        //		dir = new Vector3(
        //			dir.x/dir.magnitude,
        //			dir.y/dir.magnitude,
        //			dir.z/dir.magnitude);


        //print the Euler direction the transform is facing
        Debug.Log("Facing? " + transform.forward);

        //Print the normalized dir
        Debug.Log("Dir: " + dir);

        //confirm the magnitude of the dir is 1 after it's normalized (spoiler alert: it is)
        Debug.Log("Normalized dir? " + dir.magnitude);

        
         

          

            //rotate towards the target
           transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), .1f);
        

        //Draw a ray coming out of the front of the object
        Debug.DrawRay(transform.position, transform.forward * 3, Color.black);
        //Draw a ray coming out of the top of the object
        Debug.DrawRay(transform.position, transform.up * 3, Color.black);

        //if "space" is pressed

    }
}
