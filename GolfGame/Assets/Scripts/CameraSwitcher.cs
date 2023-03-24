using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour {
    private bool initialized = false;
    [SerializeField] private BallCameraController anchorPrefab;

    private BallCameraController[] ballCams;
    private int activeBallCam = 0;
    [SerializeField] private HoverCameraController hoverCamera;
    private bool hoverCameraActive = false;

    [SerializeField] private InputAction switchCamerasInput;

    private void OnEnable() {
        switchCamerasInput.Enable();

        switchCamerasInput.performed += switchCameras;
    }

    private void Start() {
        hoverCamera.gameObject.SetActive(false);
    }

    private void OnDisable() {
        switchCamerasInput.Disable();

        switchCamerasInput.performed -= switchCameras;
    }

    public void initialize(GameObject[] players) {
        if(initialized) {
            return;
        }

        ballCams = new BallCameraController[GameManager.NumPlayers];

        for(int i = 0; i < ballCams.Length; i++) {
            ballCams[i] = Instantiate(anchorPrefab, LevelManager.HoleStart.position, LevelManager.HoleStart.rotation);
            ballCams[i].gameObject.name = "Player" + i + "BallCameraAnchor";
            ballCams[i].initialize(players[i].transform);
            ballCams[i].gameObject.SetActive(false);
        }

        ballCams[activeBallCam].gameObject.SetActive(true);

        initialized = true;
    }

    public void switchActiveCam() {
        ballCams[activeBallCam].gameObject.SetActive(false);

        activeBallCam++;
        if(activeBallCam >= ballCams.Length) {
            activeBallCam = 0;
        }

        ballCams[activeBallCam].gameObject.SetActive(true);
    }

    private void switchCameras(InputAction.CallbackContext context) {
        hoverCameraActive = !hoverCameraActive;
        ballCams[activeBallCam].gameObject.SetActive(true);
        hoverCamera.gameObject.SetActive(hoverCameraActive);
        hoverCamera.resetTransform(ballCams[activeBallCam].transform);
    }
}
