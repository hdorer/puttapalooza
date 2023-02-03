using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private Transform cameraTransform;

    private bool rotating = false;
    [SerializeField] float sensitivity = 1.0f;

    [SerializeField] private InputAction startMovement;
    [SerializeField] private InputAction rotate;

    private void OnValidate()
    {
        cameraTransform.localPosition = offset;
    }

    private void OnEnable()
    {
        startMovement.Enable();
        rotate.Enable();

        startMovement.performed += context => rotating = true;
        startMovement.canceled += context => rotating = false;

        rotate.performed += onLook;
    }

    private void onLook(InputAction.CallbackContext context)
    {
        if (rotating)
        {
            float rotation = context.ReadValue<float>();
            rotation = rotation * sensitivity * Time.deltaTime;
            transform.Rotate(new Vector3(0, rotation, 0));
        }
    }

    private void OnDisable()
    {
        startMovement.Disable();
        rotate.Disable();
    }
}
