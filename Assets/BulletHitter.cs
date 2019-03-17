using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

 

    // Update is called once per frame
    void Update () {
		
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            AsteroidHit(col.gameObject);
        }
    }

    void AsteroidHit(GameObject Asteroid)
    {

        GameObject MiniAsteroid = GameObject.Instantiate(Asteroid);
        MiniAsteroid.transform.localScale *= 0.3f;
        MiniAsteroid.transform.position= new Vector3(transform.position.x + MiniAsteroid.GetComponent<Collider2D>().bounds.size.x*0.8f, transform.position.y + MiniAsteroid.GetComponent<Collider2D>().bounds.size.y * 0.8f, transform.position.z);
        GameObject MiniAsteroid2 = GameObject.Instantiate(Asteroid);;
       
        MiniAsteroid.transform.localScale *= 0.3f;
        MiniAsteroid2.transform.localScale *= 0.5f;
       
        Destroy(Asteroid);
        MiniAsteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(5, 35), Random.Range(5, 35)));
        MiniAsteroid2.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-25, -10), Random.Range(-35, -5)));
        MiniAsteroid2.GetComponent<Rigidbody2D>().AddTorque(21, 0);
        MiniAsteroid.GetComponent<Rigidbody2D>().AddTorque(-6, 0);
        if (MiniAsteroid.GetComponent<Collider2D>().bounds.size.x < 0.1)
            Destroy(MiniAsteroid);
        if (MiniAsteroid2.GetComponent<Collider2D>().bounds.size.x < 0.1)
            Destroy(MiniAsteroid2);
        Destroy(gameObject);
    }



}
