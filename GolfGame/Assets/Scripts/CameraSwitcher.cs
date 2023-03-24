using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour {
    [SerializeField] private GameObject ballCamera;
    [SerializeField] private GameObject hoverCamera;

    [SerializeField] private InputAction switchCamerasInput;
    private bool hoverCameraActive = false;

    private void OnEnable() {
        switchCamerasInput.Enable();

        switchCamerasInput.performed += switchCameras;
    }

    private void Start() {
        ballCamera.SetActive(true);
        hoverCamera.SetActive(false);
    }

    private void OnDisable() {
        switchCamerasInput.Disable();

        switchCamerasInput.performed -= switchCameras;
    }

    private void switchCameras(InputAction.CallbackContext context) {
        hoverCameraActive = !hoverCameraActive;
        ballCamera.SetActive(!hoverCameraActive);
        hoverCamera.SetActive(hoverCameraActive);
    }
}
