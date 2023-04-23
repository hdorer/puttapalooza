using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    [SerializeField] private float magnetRange = 3.0f;
    public float MagnetRange { get => magnetRange; }
    [SerializeField] private float magnetDeadZone = 0.5f;
    public float MagnetDeadZone { get => magnetDeadZone; }
    [SerializeField] Transform magnetPoint;
    public Vector3 MagnetPoint { get => magnetPoint.position; }
    public AudioSource audioPlayer;
    public AudioClip holeSound;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "GolfBall") {
            audioPlayer.PlayOneShot(holeSound);
            other.GetComponent<PlayerTurn>().completeHole();
            LevelManager.finishLevel();
            other.GetComponent<PlayerTurn>().endTurn(false);
        }
    }
}
