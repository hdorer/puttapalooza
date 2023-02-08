using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///DO NOT USE THIS SCRIPT IT IS FOR TESTING PURPOSES
/// </summary>

public class BallMovementScript : MonoBehaviour
{
    Rigidbody rb;
    float hitForce = 5;
    public bool allowMove = true;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(allowMove)
        {
            move();
        }
    }
    void move()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector3(1,0,0) * hitForce,ForceMode.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(new Vector3(0,0,1) * hitForce,ForceMode.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(new Vector3(-1,0,0) * hitForce,ForceMode.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(new Vector3(0,0,-1) * hitForce,ForceMode.Impulse);
        }
    }
}
