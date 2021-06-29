using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipControl : MonoBehaviour
{
    public Stats stats;
    public GameObject flame;
    float Speed = -5;
    float RotationSpeed = 1;

    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {
        float ZRotation = Input.GetAxis("Horizontal") * RotationSpeed;
        float YSpeed = Input.GetAxis("Vertical") * Speed;
        if (YSpeed < 0 && stats.Fuel > 0)
        {
           GetComponent<Rigidbody2D>().AddForce(transform.up * YSpeed);
            flame.SetActive(true);
            stats.Fuel-=0.1f;
        }
        else
        {
            flame.SetActive(false);
        }
        GetComponent<Rigidbody2D>().AddTorque(-ZRotation, 0);
        



    }
}