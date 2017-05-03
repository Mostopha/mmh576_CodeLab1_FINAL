using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour {

    public Transform target;
 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
        Vector3 dir = target.position - transform.position;

 
        dir.Normalize();
           transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), .1f);
        


        Debug.DrawRay(transform.position, transform.forward * 3, Color.black);
  
        Debug.DrawRay(transform.position, transform.up * 3, Color.black);

   

    }
}
