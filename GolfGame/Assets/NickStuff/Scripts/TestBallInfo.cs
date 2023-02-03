using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Test Script for reset pos, and movement
/// </summary>

public class TestBallInfo : MonoBehaviour
{
    Vector3 playerPos;
    Rigidbody rb;
    BallMovementScript bms;
    bool playerTurn = false;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.CompareTag("GolfBall"))
        {
            playerTurn = true;
        }
        playerPos = gameObject.transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
        bms = gameObject.GetComponent<BallMovementScript>();
    }

    void OnEnabled()
    {
        playerPos = gameObject.transform.position;
        playerTurn = true;
        //Your Turn
    }
    void OnDisabled()
    {
        playerTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        BallStateCheck();
    }
    void BallStateCheck()
    {
        if(playerTurn && rb.velocity == Vector3.zero && bms.allowMove)
        {
            Debug.Log("Ball stopped player's turn now");
        }
        if(playerTurn && rb.velocity != Vector3.zero)
        {
            Debug.Log("Ball started movement");
            playerTurn = false;
            bms.allowMove = false;
        }
        if(!playerTurn && rb.velocity == Vector3.zero)
        {
            Debug.Log("Ball stopped player's turn over");
            playerPos = gameObject.transform.position;
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Reset"))
        {
            gameObject.transform.position = playerPos;
            playerTurn = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            bms.allowMove = true;
        }
    }
}
