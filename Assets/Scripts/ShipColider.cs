using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipColider : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            AsteroidHit(col.gameObject);
            GetComponent<Stats>().HP = GetComponent<Stats>().HP - 20;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FuelCrate")
        {
            FuelCrateHit(collision.gameObject);
        }
    }

    void AsteroidHit(GameObject Asteroid)
    {
       
        GameObject MiniAsteroid = GameObject.Instantiate(Asteroid);
        MiniAsteroid.transform.localScale *= 0.5f;
        Destroy(Asteroid);

    }

    void FuelCrateHit(GameObject Crate)
    {
        Destroy(Crate);
        GetComponent<Stats>().Fuel += 10;
        if (GetComponent<Stats>().Fuel > GetComponent<Stats>().MaxFuel)
            GetComponent<Stats>().Fuel = GetComponent<Stats>().MaxFuel;
        Destroy(Crate);
    }
}
