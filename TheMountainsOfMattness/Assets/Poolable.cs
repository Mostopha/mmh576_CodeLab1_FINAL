using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour {
    public GameObject player;
    public float maxDistance;
    public float moveSpeed = 100;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (RePool())
        {
            ObjectivePool.AddToPool(gameObject);
        }
    }

    public bool RePool()
    {

        return Vector3.Distance(player.transform.position, transform.position) > maxDistance;

        
         /*   if(Vector3.Distance(player.transform.position, transform.position) > maxDistance)
            {
                return true;
            }
            return false;*/
     }
    
    public void Reset()
    {
        if(player == null)
        {
            player = GameObject.Find("Player");
        }

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * moveSpeed);
       
        
        transform.position = player.transform.position + new Vector3(0, 1, 0);

    }


}
