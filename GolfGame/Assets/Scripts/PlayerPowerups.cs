using System.Collections;
using System.Collections.Generic;
using Powerups;
using UnityEngine;

public class PlayerPowerups : MonoBehaviour {
    private Powerup powerup;
    public Powerup Powerup { set { powerup = value; Debug.Log("Powerup recieved: " + powerup.Name); } }

    public void usePowerup() {
        powerup.use();
    }
}
