using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        transform.position = target;
        
    }
}
