using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject bullet;
    public float speed = 5.0f;

    public float ammo = 10;


    public float barDisplay; //current progress
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;


    void OnGUI()
    {
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    // Use this for initialization
    void Start()
    {

    }



    void Update()
    {

        barDisplay = ammo*0.10f;

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



        if (Input.GetMouseButtonDown(1))
        { //On mouse button down
            RaycastHit rayHit; //create a RaycastHit object

            //Call the Physics.Raycast function with Camera world position of the mouse, the rayHit object, and the far clipping plane
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Camera.main.farClipPlane))
            {
                Debug.Log(rayHit.collider.name); //Print the name of the object
                if (rayHit.collider.tag == "Facts")
                {
                    Debug.Log("Ammo Restored");
                    ammo = 10;
                }
            }
            else
            {
                Debug.Log("Hit nothing"); //if you hit nothing, print that
            }
        }



    }
}
