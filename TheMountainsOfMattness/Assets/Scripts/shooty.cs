using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooty : MonoBehaviour {

    GameObject forwardBullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    GameObject leftBullet= GameObject.CreatePrimitive(PrimitiveType.Sphere);
    GameObject rightBullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 vec1 = Vector3.Normalize(transform.forward);
        Vector3 vec2 = Vector3.Normalize(transform.up);

        Vector3 sides = Vector3.Cross(vec1, vec2);
        Vector3 otherSide = sides * -1;

       
            GameObject forwardBullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            forwardBullet.transform.position = transform.position;


            GameObject leftBullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            leftBullet.transform.position = transform.position+sides;
            leftBullet.AddComponent<Rigidbody>();
            leftBullet.GetComponent<Rigidbody>().AddForce(sides * 10);



            GameObject rightBullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            rightBullet.transform.position = transform.position-sides;
            rightBullet.AddComponent<Rigidbody>();
            rightBullet.GetComponent<Rigidbody>().AddForce(otherSide * 10);
        

    }
}
