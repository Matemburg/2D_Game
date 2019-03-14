using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipControl : MonoBehaviour
{


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
        GetComponent<Rigidbody2D>().AddTorque(-ZRotation, 0);
        GetComponent<Rigidbody2D>().AddForce(transform.up * YSpeed);



    }
}