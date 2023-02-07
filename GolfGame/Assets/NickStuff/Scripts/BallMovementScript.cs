using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///DO NOT USE THIS SCRIPT IT IS FOR TESTING PURPOSES
/// </summary>

public class BallMovementScript : MonoBehaviour
{
    Rigidbody rb;
    public int hitPowerMod = 5;
    float hitForce = 0;
    float mouseHitForce = 0.0f;
    Vector3 hitDirection = Vector3.zero;
    Vector3 hitDirectionStart = Vector3.zero;
    Vector3 hitDirectionEnd = Vector3.zero;
    public bool allowMove = true;
    private bool Aim = false;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(allowMove)
        {
            //Display Text on Screen saying your turn
            mouseMove();
            //move();
        }
    }
    void mouseMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hitDirectionStart = Input.mousePosition;
            Aim = true;
        }

        if(Aim)
        {
            hitForce -= Input.GetAxis("Mouse Y")*hitPowerMod;
            if(hitForce <= 0)
            {
                hitForce = 0;
            }
            if(hitForce >= 100)
            {
                hitForce = 100;
            }
            Debug.Log("Current Force: "+hitForce);   
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            
            hitDirectionEnd = Input.mousePosition;

            Debug.Log("Start "+hitDirectionStart);
            Debug.Log("End "+hitDirectionEnd);

            hitDirection = hitDirectionEnd - hitDirectionStart;
            hitDirection = Vector3.Normalize(hitDirection);
            hitDirection = new Vector3(hitDirection.x, 0, hitDirection.y);
            

            Debug.Log("Sub: "+hitDirection);

            Aim = false;
            if(hitForce > 0.1)
            {
                Debug.Log("Hitforce: " + hitForce);
                rb.AddForce(-hitDirection*hitForce,ForceMode.Impulse);
                allowMove = false;
            }
            else
            {
                allowMove = true;
            }
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
