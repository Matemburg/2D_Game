using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    private GameObject targetEnemy;
    public GameObject partToRotate;
    public float range = 15f;
    private float angle = 0;
    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        LockOnTarget();
        Quaternion OldRotation = transform.rotation;
        transform.Rotate(0, 0, -angle);
        transform.rotation = Quaternion.Slerp(OldRotation, transform.rotation, Time.deltaTime);


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
            targetEnemy = nearestEnemy;
        }
        else
        {
            target = null;
        }

    }

    void LockOnTarget()
    {

       // float angle = 0;

        Vector3 relative = transform.InverseTransformPoint(target.position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
      
       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
