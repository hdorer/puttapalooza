using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    [SerializeField] private float magnetRange = 3.0f;
    public float MagnetRange { get => magnetRange; }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "GolfBall") {
            Debug.Log("Clack!  Hole reached");
        }
    }
}
