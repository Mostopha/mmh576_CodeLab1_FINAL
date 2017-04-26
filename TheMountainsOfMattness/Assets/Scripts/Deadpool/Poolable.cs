using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Poolable : MonoBehaviour {
   
 

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

    public abstract void Setup();


    public abstract bool RePool();

    public abstract void Reset();
    


}
