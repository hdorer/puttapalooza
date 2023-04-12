using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoverCameraController : MonoBehaviour {
    [SerializeField] private float distanceToGround = 10f;
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

        int layerMask = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, layerMask);
        // Debug.Log(hit.point.y);

        transform.position = new Vector3(transform.position.x, hit.point.y + distanceToGround, transform.position.z);
    }

    private void OnDisable() {
        movementInput.Disable();

        movementInput.performed -= updateMoveVector;
        movementInput.canceled -= updateMoveVector;
    }

    public void resetTransform(Transform anchor) {
        transform.position = new Vector3(anchor.position.x, transform.position.y, anchor.position.z);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, anchor.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    private void updateMoveVector(InputAction.CallbackContext context) {
        Vector2 inputValue = context.ReadValue<Vector2>();

        movement = inputValue;
    }
}
