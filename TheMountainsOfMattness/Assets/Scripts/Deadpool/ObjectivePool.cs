using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePool:MonoBehaviour{

    public enum types
    {
        BULLET, ENEMY
    }

    public types type;

    public static Queue<GameObject> bulletPool = new Queue<GameObject>();
    public static Queue<GameObject> enemyPool = new Queue<GameObject>();

    public static GameObject GetFromPool(types type)
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

        Poolable P = obj.GetComponent<Poolable>();

        if(P is PoolableBullet)
        {
            bulletPool.Enqueue(obj);
        }else if(P is PoolableEnemy)
        {
            enemyPool.Enqueue(obj);
        }else
        {
            print ("You have not implemented a pool for this object");
        }



      /*  if (obj.GetComponent<PoolableBullet>()!=null)
        {
            bulletPool.Enqueue(obj);
        }
        bulletPool.Enqueue(obj);*/

    }

}
