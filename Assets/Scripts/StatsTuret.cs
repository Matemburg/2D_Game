using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTuret : MonoBehaviour
{
    public GameObject LevelSystem;
    public GameObject EventSystem;
    public int HP = 100;
    public int maxHP = 100;
    public GameObject FuelCrate;
    // Use this for initialization
    void Start()
    {
        LevelSystem = GameObject.FindGameObjectWithTag("LevelSystem");
        EventSystem = GameObject.FindGameObjectWithTag("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 0)
        {
            LevelSystem.GetComponent<LevelSystem>().TuretNumber -= 1;
            EventSystem.GetComponent<Stats>().turretdestroyed ++;
            Instantiate(FuelCrate, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
