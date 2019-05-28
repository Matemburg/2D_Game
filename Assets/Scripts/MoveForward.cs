using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float maxSpeed = 5f;
    public float spreadFactor = 1f;

    private void Start()
    {
        Vector3 direction = transform.eulerAngles;

     
        direction.z += Random.Range(-spreadFactor, spreadFactor);

        transform.eulerAngles = direction;
    }

    // Update is called once per frame
    void FixedUpdate () {
		Vector3 pos = transform.position;
		
		Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
		
		pos += transform.rotation * velocity;

		transform.position = pos;
	}
}
