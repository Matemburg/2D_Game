using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRandomSpawner : MonoBehaviour {

    public GameObject[] Asteroids;
    public GameObject Ship;

    public int AsteroidNumber;

    public float xMin;
    public float xMax;


    public float yMin;
    public float yMax;

    void Start() {
        for (int x = 0; x < AsteroidNumber; x++) {
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
                Instantiate(Asteroids[Random.Range(0, Asteroids.Length)], pos, transform.rotation);

            }
        }
}	

