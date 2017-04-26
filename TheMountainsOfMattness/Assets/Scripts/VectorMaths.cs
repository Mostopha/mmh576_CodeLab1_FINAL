using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMaths : MonoBehaviour {

    public Vector3 startPoint = new Vector3(0, 0, 0);
    public Vector3 vec1 = new Vector3(10, 10, 0);
    public Vector3 vec2 = new Vector3(0, 0, 10);
    public Vector3 inAngle = new Vector3(10, 10, 10);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(startPoint, vec1, Color.green);

        Debug.Log("Vec1 Mag: " + vec1.magnitude);
        Debug.Log("Vec 1 Normalized:" + Vector3.Normalize(vec1));

        Debug.Log(Vector3.Dot(Vector3.right, Vector3.down));
        Debug.DrawRay(startPoint, vec1, Color.white);
        Debug.DrawRay(startPoint, vec2, Color.white);


        Vector3 cross = Vector3.Cross(vec1, vec2);

        Debug.DrawRay(startPoint, cross, Color.yellow);
        Debug.DrawRay(startPoint, inAngle, Color.red);

        Vector3 reflection = Vector3.Reflect(inAngle, -cross);
        Debug.DrawRay(startPoint, -reflection, Color.blue);

    }
}
