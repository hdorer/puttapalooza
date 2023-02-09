using System.Collections;
using System.Collections.Generic;
using Powerups;
using UnityEngine;

public class PowerupPickup : MonoBehaviour {
    [SerializeField] Powerup powerup;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "GolfBall") {
            other.GetComponent<PlayerPowerups>().Powerup = powerup;
            Destroy(gameObject);
        }
    }
}
