using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoverCameraController : MonoBehaviour {
    [SerializeField] private Transform ballCameraAnchor;

    [SerializeField] private float movementSpeed = 5.0f;

    [SerializeField] private InputAction movementInput;
    Vector2 movement;
    

    private void OnEnable() {
        movementInput.Enable();

        movementInput.performed += updateMoveVector;
        movementInput.canceled += updateMoveVector;
    }

    private void Update() {
        transform.position += transform.right * movement.x;
        transform.position += transform.up * movement.y;
    }

    private void OnDisable() {
        movementInput.Disable();

        movementInput.performed -= updateMoveVector;
        movementInput.canceled -= updateMoveVector;
    }

    public void resetTransform() {
        transform.position = new Vector3(ballCameraAnchor.position.x, transform.position.y, ballCameraAnchor.position.z);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, ballCameraAnchor.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    private void updateMoveVector(InputAction.CallbackContext context) {
        Vector2 inputValue = context.ReadValue<Vector2>();

        movement = inputValue;
    }
}
