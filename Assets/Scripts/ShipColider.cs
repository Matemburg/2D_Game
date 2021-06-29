using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipColider : MonoBehaviour {

    public Stats stats;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            AsteroidHit(col.gameObject);
            stats.HP = stats.HP - 20;
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
        stats.Fuel += 25;
        if (stats.Fuel > stats.MaxFuel)
            stats.Fuel = stats.MaxFuel;
        Destroy(Crate);
    }
}
