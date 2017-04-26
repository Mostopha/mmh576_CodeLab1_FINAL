using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePool:MonoBehaviour{

    public static Queue<GameObject> pool = new Queue<GameObject>();

    public static GameObject GetFromPool()
    {
        GameObject bullet;

        if (pool.Count > 0)
        {
            bullet = pool.Dequeue();
            bullet.SetActive(true);

        }else
        {
            bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
        }

        bullet.GetComponent<Poolable>().Reset();

        return bullet;

   }
    public static void AddToPool(GameObject obj){
        obj.SetActive(false);
        pool.Enqueue(obj);

    }

}
