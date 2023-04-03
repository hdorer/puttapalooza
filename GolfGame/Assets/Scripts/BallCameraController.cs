using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallCameraController : MonoBehaviour {
    private bool initialized = false;

    private Transform ball;

    private bool rotating = false;
    [SerializeField] private float sensitivity = 1.0f;

    [SerializeField] private InputAction startMovement;
    [SerializeField] private InputAction rotate;

    public Transform Ball { set => ball = value; }

    private void OnEnable() {
        startMovement.Enable();
        rotate.Enable();

        startMovement.performed += context => rotating = true;
        startMovement.canceled += context => rotating = false;

        rotate.performed += onLook;
    }

    private void Update() {
        transform.position = ball.position;
    }

    private void OnDisable() {
        startMovement.Disable();
        rotate.Disable();
    }

    public void initialize(Transform ball) {
        if(initialized) {
            return;
        }

        this.ball = ball;

        initialized = true;
    }

    private void onLook(InputAction.CallbackContext context) {
        if(rotating) {
            float rotation = context.ReadValue<float>();
            rotation = rotation * sensitivity * Time.deltaTime;
            transform.Rotate(new Vector3(0, rotation, 0));
        }
    }
}
