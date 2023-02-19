using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private InputAction aim;
    [SerializeField] private InputAction confirm;
    [SerializeField] private InputAction goBack;
    [SerializeField] private InputAction doDebug;

    private bool isAim, isFire;
    public bool isTurn = true;

    private float angle = 0;
    private Vector3 hitDirection = Vector3.forward;
    [SerializeField] private Rigidbody rb;
    private Vector3 hitForce = Vector3.zero;
    [SerializeField] private float hitPower;

    private void OnEnable() {
        aim.Enable();
        confirm.Enable();
        goBack.Enable();
        doDebug.Enable();

        aim.performed += onAim;
        confirm.performed += onConfirm;
        goBack.performed += onGoBack;
        doDebug.performed += onDebug;
    }

    private void OnDisable() {
        aim.performed -= onAim;
        confirm.performed -= onConfirm;
        goBack.performed -= onGoBack;
        doDebug.performed -= onDebug;
        
        aim.Disable();
        confirm.Disable();
        goBack.Disable();
        doDebug.Disable();
    }

    private void Update()
    {
        if(isTurn)
        {
            if(isFire)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    isFire = false;
                    isAim = false;


                    hitForce = hitDirection * hitPower;
                    rb.AddForce(hitForce, ForceMode.Impulse);
                }
            }
        }
    }

    private void DebugLog()
    {
        Debug.Log("Angle: " + angle);
        Debug.Log("hit direction: " + hitDirection);
        Debug.Log("hit force: " + hitForce);
        Debug.Log("Is Turn: " + isTurn);
        Debug.Log("Is Aim: " + isAim);
        Debug.Log("Is hit: " + isFire);

    }

    //This is for Q and E to rotate the direction the ball will go
    private void onAim(InputAction.CallbackContext context) {
        Debug.Log("aim " + context.ReadValue<float>());
        if(context.ReadValue<float>() > 0)
        {
            //rotate right
            angle += 1;
            if(angle > 360)
            {
                angle = 0;
            }
        }
        else if(context.ReadValue<float>() < 0)
        {
            //rotate left
            angle -= 1;
            if(angle < -360)
            {
                angle = 0;
            }
        }

        hitDirection = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward;
        //hitDirection = Vector3.RotateTowards(Vector3.forward,Vector3.up,angle, 0);
    }
    //This is to continue from aim and item use to hitting
    private void onConfirm(InputAction.CallbackContext context) {
        Debug.Log("confirm");
        isAim = false;
        isFire = true;
    }
    //This is to go from hitting the ball to item and aim
    private void onGoBack(InputAction.CallbackContext context) {
        Debug.Log("go back");
        isAim = true;
        isFire = false;
    }
    //Prints a debug log
    private void onDebug(InputAction.CallbackContext context)
    {
        DebugLog();
    }
}
