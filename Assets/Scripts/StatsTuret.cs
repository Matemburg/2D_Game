using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTuret : MonoBehaviour
{
    public GameObject TuretSpawner;
    public int HP = 100;
    public int maxHP = 100;
    public GameObject FuelCrate;
    // Use this for initialization
    void Start()
    {
        TuretSpawner = GameObject.FindGameObjectWithTag("TuretSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 0)
        {
            TuretSpawner.GetComponent<TuretRandomSpawner>().TuretNumber -= 1; 
            
            Instantiate(FuelCrate, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
