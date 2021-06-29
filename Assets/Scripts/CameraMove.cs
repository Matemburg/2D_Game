using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject SpaceShip;
	public int z = -5;
	
	void LateUpdate () {
        transform.position= new Vector3 (SpaceShip.transform.position.x, SpaceShip.transform.position.y,z);

	}
}
