using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

     public int HP=100;
     public int MaxHP=100;
     public float Fuel = 100;
     public float MaxFuel = 100;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (HP < 0)
            Destroy(gameObject);
		
	}
}
