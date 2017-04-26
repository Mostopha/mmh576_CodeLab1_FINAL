using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooty2 : MonoBehaviour {
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        moveSpeed = 200;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Vector3 modPos = new Vector3(0, 1, 0);

            // GameObject bullet = Instantiate(Resources.Load("Bullet"), transform.position+modPos, Quaternion.identity) as GameObject;

            GameObject bullet = ObjectivePool.GetFromPool();

            bullet.transform.position = transform.position + modPos;

            bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * moveSpeed);
        }
		
	}
}
