using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject SpaceShip;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position= new Vector3 (SpaceShip.transform.position.x, SpaceShip.transform.position.y,-5);

	}
}
