using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableBullet : Poolable {

    public GameObject player;
    public float maxDistance= 5;
    public float moveSpeed = 100;


    // Use this for initialization
	
	// Update is called once per frame
	

    public override void Setup()
    {
        //base.Setup();
        player = GameObject.Find("Player");
    }

    public override bool RePool()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }


        return Vector3.Distance(player.transform.position, transform.position) > maxDistance;


          /* if(Vector3.Distance(player.transform.position, transform.position) > maxDistance)
           {
               return true;
           }
           return false;*/
    }

    public override void Reset()
    {
        print("Reset");

         if(player == null)
         {
             player = GameObject.Find("Player");
         }

        Rigidbody rb = GetComponent<Rigidbody>();
        transform.position = player.transform.position + new Vector3(0, 1, 0);

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * moveSpeed);

    }
}
