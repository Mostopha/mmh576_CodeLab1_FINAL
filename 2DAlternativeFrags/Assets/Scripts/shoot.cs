using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject bullet;
    public float speed = 5.0f;

    public float ammo = 10;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (ammo > 0)

        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                // GameObject projectile = (GameObject)Instantiate(bullet, myPos, Quaternion.identity);

                GameObject projectile = ObjectPool.GetFromPool(Poolable.types.BULLET);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;



                Physics2D.GetIgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

                ammo--;
            }
        }







    }
}
