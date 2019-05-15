using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuretRandomSpawner : MonoBehaviour {

    public GameObject[] Turet;
    private List<GameObject> SpawnedTurets;

    public int TuretNumber;

    public float xMin;
    public float xMax;


    public float yMin;
    public float yMax;

    void Awake()
    {
        SpawnedTurets = new List<GameObject>();
        for (int x = 0; x < TuretNumber; x++)
        {
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            GameObject turet = Instantiate(Turet[Random.Range(0, Turet.Length)], pos, transform.rotation);
            SpawnedTurets.Add(turet);
        }
    }

    public List<GameObject> getSpawnedTurets()
    {
        return SpawnedTurets;
    }
}
