using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePool:MonoBehaviour{

    public static Queue<GameObject> bulletPool = new Queue<GameObject>();
    public static Queue<GameObject> enemyPool = new Queue<GameObject>();

    public static GameObject GetFromPool()
    {
        GameObject bullet;

        if (bulletPool.Count > 0)
        {
            bullet = bulletPool.Dequeue();
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
        bulletPool.Enqueue(obj);

    }

}
