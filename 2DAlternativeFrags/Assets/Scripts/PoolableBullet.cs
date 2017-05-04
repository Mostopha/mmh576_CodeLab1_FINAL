using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableBullet : Poolable
{ 

    public float maxDistance; 
    public float moveSpeed = 100; 
    GameObject player;

    public override void Setup() //override Setup (you have to, because it's abstract)
    {
        player = GameObject.Find("Player"); //get a reference to the "Player" object
    }

    public override bool RePool()
    { 
        return Vector3.Distance(player.transform.position, transform.position) > maxDistance; 
    }

    public override void Reset()
    { //override Reset (you have to, because it's abstract)
        print("Reset");

        if (player == null)
        { //if we don't have a reference to the player yet
            player = GameObject.Find("Player"); //get a ref to the player
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>(); //get the rigidBody attached to this bullet
        transform.position = player.transform.position + new Vector3(0, 1, 0); //put the bullet near the player

        print(player.transform.position);

        
    }
}
