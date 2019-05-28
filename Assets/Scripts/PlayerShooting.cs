using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

	public GameObject bulletPrefab;


	public float fireDelay = 0.25f;
	float cooldownTimer = 0;

    public AudioClip sound;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void Start() {

        gameObject.AddComponent<AudioSource>();

        source.clip = sound;

        source.playOnAwake = false;
    }

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if( Input.GetButton("Fire1") && cooldownTimer <= 0 ) {

			cooldownTimer = fireDelay;
            source.PlayOneShot(sound);
            Vector3 offset = transform.rotation * bulletOffset;

			GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);

		}


	}

   
}
