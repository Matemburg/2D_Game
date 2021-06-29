using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerTransformLookat : MonoBehaviour {

    public GameObject ship;
    GameObject Target;
    public GameObject[] turets;

    void Update () {
        transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y + 5f);
        turets = GameObject.FindGameObjectsWithTag  ("Turet");

        float min = -1;
        Target=turets[0];

        foreach (GameObject turet in turets)
        {
           float  temp = ((turet.transform.position - ship.transform.position).sqrMagnitude);
            if (min == -1)
            {
                min = temp;
                Target = turet;
            }
            else if (min > temp)
            {
                min = temp;
                Target = turet;
            }
        }
        Vector3 diff = Target.transform.position - ship.transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }


}
