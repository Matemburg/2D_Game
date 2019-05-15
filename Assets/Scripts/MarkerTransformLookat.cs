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
        Quaternion rotation = Quaternion.LookRotation
             (Target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w-0.5f);
    }


}
