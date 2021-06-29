using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {


    public GameObject LevelSystem;

    private Transform target;
    private Vector3 targetVelocity;
    private int projectileSpeed = 25;

    public GameObject partToRotate;
    public GameObject ShotingPoint;
    public double range = 7.5;
    private float angle = 0;
    public double Turnspeed = 5;
    public GameObject bulletPrefab;

    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;


    // Use this for initialization
    void Start () {
        LevelSystem = GameObject.FindGameObjectWithTag("LevelSystem");
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        gameObject.AddComponent<AudioSource>();

        source.clip = sound;

        source.playOnAwake = false;
    }
	
	// Update is called once per frame
	void Update () {
        range = 7.5 + (LevelSystem.GetComponent<LevelSystem>().Level * 0.5);
        Turnspeed = 5 + (LevelSystem.GetComponent<LevelSystem>().Level * 0.5);
        if (LockOnTarget())
        {
            Quaternion OldRotation = partToRotate.transform.rotation;
            partToRotate.transform.Rotate(0, 0, -angle);
            partToRotate.transform.rotation = Quaternion.Lerp(OldRotation, partToRotate.transform.rotation, Time.deltaTime * (float)Turnspeed);

            cooldownTimer -= Time.deltaTime;

            if (System.Math.Abs(angle) < 15 && cooldownTimer < 0)
            {


                source.PlayOneShot(sound);
                // SHOOT!
                cooldownTimer = fireDelay;



                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, ShotingPoint.transform.position, partToRotate.transform.rotation * new Quaternion(0, 0, -1, 0));
                ;

            }

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

    bool LockOnTarget()
    {

        // float angle = 0;
        try
        {
            Vector3 relative = partToRotate.transform.InverseTransformPoint(predictedPosition());
            angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            return true;
        }
        catch {
            return false;
        }
       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, (float)range);
    }


    private Vector3 predictedPosition()
    {
        Vector3 targetPosition = target.transform.position;
        targetVelocity = target.gameObject.GetComponent<Rigidbody2D>().velocity;
        Vector3 shooterPosition = this.gameObject.transform.position;
        Vector3 displacement = targetPosition - shooterPosition;
        float targetMoveAngle = Vector3.Angle(-displacement, targetVelocity) * Mathf.Deg2Rad;
        //if the target is stopping or if it is impossible for the projectile to catch up with the target (Sine Formula)
        if (targetVelocity.magnitude == 0 || targetVelocity.magnitude > projectileSpeed && Mathf.Sin(targetMoveAngle) / projectileSpeed > Mathf.Cos(targetMoveAngle) / targetVelocity.magnitude)
        {
            Debug.Log("Position prediction is not feasible.");
            return targetPosition;
        }
        //also Sine Formula
        float shootAngle = Mathf.Asin(Mathf.Sin(targetMoveAngle) * targetVelocity.magnitude / projectileSpeed);
        return targetPosition + targetVelocity * displacement.magnitude / Mathf.Sin(Mathf.PI - targetMoveAngle - shootAngle) * Mathf.Sin(shootAngle) / targetVelocity.magnitude;
    }

}
