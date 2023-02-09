using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPickupRotator : MonoBehaviour {
    private const float rotationSpeed = 50f;
    private const float yMoveScalar = 0.3f;
    private float startingY;

    private void Start() {
        startingY = transform.position.y;
    }

    private void Update() {
        float y = startingY + Mathf.Sin(Time.timeSinceLevelLoad) * yMoveScalar;

        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
