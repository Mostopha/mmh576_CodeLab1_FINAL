using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableEnemy : Poolable {

    public bool gotHit;

    public override void Setup()
    {
        
    }

    public override bool RePool()
    {
        return gotHit;
    }

    public override void Reset()
    {
       
        
    }

}
