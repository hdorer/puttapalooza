using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Intended to be the base class for the golf ball
//Holds if its your turn, turn num (player 1 is turn num 1)
//Holds position, Power up (which one)
//Player Id (what ever is really needed for networking)

public class PlayerGolfBall : MonoBehaviour
{
    private bool isTurn;
    public bool IsTurn { get => isTurn; set => isTurn = value; }
    private int TurnNum;
    Vector3 PlayerPosition;
    public string PowerUpName;
    private int PlayerId;

    // Update is called once per frame
    void Update()
    {
        
    }
}
