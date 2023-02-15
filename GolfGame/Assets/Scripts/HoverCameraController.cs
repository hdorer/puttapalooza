using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoverCameraController : MonoBehaviour {
    [SerializeField] private Transform ballCameraAnchor;

    [SerializeField] private float movementSpeed = 5.0f;

    [SerializeField] private InputAction movementInput;
    

    private void OnEnable() {
        movementInput.Enable();
    }

    private void OnDisable() {
        movementInput.Disable();
    }

    public void resetTransform() {
        // transform.position = new Vector3(ballCameraAnchor.position.x, transform.position.y, ballCameraAnchor.position.z);
        // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, ballCameraAnchor.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        Debug.Log("OnCameraLive");
    }

    
}
