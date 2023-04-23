using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPickup : MonoBehaviour {
    [SerializeField] Powerup powerup;
    public AudioSource audioPlayer;
    public AudioClip pickupSound;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "GolfBall") {
            audioPlayer.PlayOneShot(pickupSound);
            other.GetComponent<PlayerPowerups>().setPowerup(powerup);
            Destroy(gameObject);
        }
    }
}
