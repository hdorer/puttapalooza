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

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "GolfBall") {
            other.GetComponent<PlayerScore>().saveScore();
            LevelManager.loadNextLevel();
        }
    }
}
