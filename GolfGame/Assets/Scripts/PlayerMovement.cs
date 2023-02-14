using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private InputAction aim;
    [SerializeField] private InputAction confirm;
    [SerializeField] private InputAction goBack;

    private void OnEnable() {
        aim.Enable();
        confirm.Enable();
        goBack.Enable();

        aim.performed += onAim;
        confirm.performed += onConfirm;
        goBack.performed += onGoBack;
    }

    private void OnDisable() {
        aim.performed -= onAim;
        confirm.performed -= onConfirm;
        goBack.performed -= onGoBack;
        
        aim.Disable();
        confirm.Disable();
        goBack.Disable();
    }

    private void onAim(InputAction.CallbackContext context) {
        Debug.Log("aim " + context.ReadValue<float>());
    }

    private void onConfirm(InputAction.CallbackContext context) {
        Debug.Log("confirm");
    }

    private void onGoBack(InputAction.CallbackContext context) {
        Debug.Log("go back");
    }
}
