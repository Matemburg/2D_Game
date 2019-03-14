using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float timer = 1f;

	void Update () {
        timer--;

		if(timer <= 0) {
			Destroy(this.gameObject);
		}
	}
}
