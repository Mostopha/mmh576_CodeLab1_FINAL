using System.Collections;
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

       
       
        if (Vector3.Dot(transform.forward, dir) > 0)
        {
          
            Debug.DrawRay(transform.position, dir, Color.cyan);

           
            transform.position += dir * speed * Time.deltaTime;

          
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), .1f);
        }

       
        Debug.DrawRay(transform.position, transform.forward * 3, Color.black);
      
        Debug.DrawRay(transform.position, transform.up * 3, Color.black);

       
   
    }
}
