using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallCameraController : MonoBehaviour {
    private bool initialized = false;

    private Transform ball;

    private bool rotating = false;
    [SerializeField] private float sensitivity = 1.0f;
    private float xAngle = 0f;
    private float minXAngle = 0f;
    private float maxXAngle = 70.0f;
    private float yAngle = 0f;

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
            Vector2 rotation = context.ReadValue<Vector2>();
            float xRotation = rotation.y;
            float yRotation = rotation.x;

            xRotation *= sensitivity * Time.deltaTime;
            yRotation *= sensitivity * Time.deltaTime;

            xAngle += xRotation;
            xAngle = Mathf.Clamp(xAngle, minXAngle, maxXAngle);
            yAngle += yRotation;
            transform.eulerAngles = new Vector3(xAngle, yAngle, 0);
        }
    }
}
