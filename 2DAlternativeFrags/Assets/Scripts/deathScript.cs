using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour {
    public float health = 5;
    private Color enemyColor;
    private Color lerpedColor;

	// Use this for initialization
	void Start () {
        enemyColor = gameObject.GetComponent<MeshRenderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {

       // gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(lerpedColor, enemyColor, 1);

        if (health < 1)
        {
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(coll.gameObject);
            Invoke("Restart", 2);
        }

        if (coll.gameObject.tag == "Bullet")
        {
            health--;

            Destroy(coll.gameObject);
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            lerpedColor = gameObject.GetComponent<MeshRenderer>().material.color;
            Invoke("lerpColor", 0.25f);
        }

    }

    void Restart()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    void lerpColor()
    {
        //gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(lerpedColor, enemyColor, 100);

        gameObject.GetComponent<MeshRenderer>().material.color = enemyColor;
    }
}


