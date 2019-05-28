using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    

    private Transform target;

    public GameObject partToRotate;
    public GameObject ShotingPoint;
    public float range = 15f;
    private float angle = 0;
    public float Turnspeed = 5f;
    public GameObject bulletPrefab;

    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;


    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        gameObject.AddComponent<AudioSource>();

        source.clip = sound;

        source.playOnAwake = false;
    }
	
	// Update is called once per frame
	void Update () {
        LockOnTarget();
        Quaternion OldRotation = partToRotate.transform.rotation;
        partToRotate.transform.Rotate(0, 0, -angle);
        partToRotate.transform.rotation = Quaternion.Lerp(OldRotation, partToRotate.transform.rotation, Time.deltaTime*Turnspeed);

        cooldownTimer -= Time.deltaTime;

        if (System.Math.Abs(angle)<15 && cooldownTimer<0)
        {


            source.PlayOneShot(sound);
            // SHOOT!
            cooldownTimer = fireDelay;

                

                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, ShotingPoint.transform.position, partToRotate.transform.rotation*new Quaternion(0,0,-1,0));
;
            
        }


    }


    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    void LockOnTarget()
    {

       // float angle = 0;

        Vector3 relative = partToRotate.transform.InverseTransformPoint(target.position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
      
       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
