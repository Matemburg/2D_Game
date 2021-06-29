using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRandomSpawner : MonoBehaviour
{

    public GameObject[] Asteroids;
    public GameObject Ship;

    private List<GameObject> Turets;

    public int AsteroidNumber;

    public float xMin;
    public float xMax;


    public float yMin;
    public float yMax;

    public void Spawn()
    {
        Turets =  GameObject.FindGameObjectWithTag("TuretSpawner").GetComponent<TuretRandomSpawner>().getSpawnedTurets();
        for (int x = 0; x < AsteroidNumber; x++)
        {
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            bool spawn = true;
            foreach (GameObject turet in Turets)
            {
                if (System.Math.Abs(pos.x - turet.transform.position.x) < 2)
                {
                    spawn = false;
                    AsteroidNumber++;
                    //break;
                }
                else if(System.Math.Abs(pos.y - turet.transform.position.y) < 2)
                {
                    spawn = false;
                    AsteroidNumber++;
                    //break;
                }
            }
            if(spawn)
              Instantiate(Asteroids[Random.Range(0, Asteroids.Length)], pos, transform.rotation);
        }


    }
    public void Destroy()
    {
        foreach(GameObject Asteroid in Asteroids){
            Destroy(Asteroid.gameObject);
        }
    }
}
