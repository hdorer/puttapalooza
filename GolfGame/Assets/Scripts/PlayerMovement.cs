using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private InputAction aim;
    [SerializeField] private InputAction confirm;
    [SerializeField] private InputAction goBack;
    [SerializeField] private InputAction doDebug;

    private bool isAim = true;
    public bool IsAim { get => isAim; }
    private bool isFire = false;
    private bool isTurn = true;
    public bool isMoving { get => rb.velocity.magnitude >= stoppingSpeed; }

    [SerializeField] private float stoppingSpeed = 0.1f;
    private float angle = 0;
    private Vector3 hitDirection = Vector3.forward;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LineRenderer line;
    private Vector3 hitForce = Vector3.zero;
    [SerializeField] private float hitPower;

    [SerializeField] private Hole hole;
    private bool magnetized;

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

    private void Update() {
        if(!isTurn) {
            if(isAim) {
                line.enabled = true;
                line.SetPosition(0, gameObject.transform.position);
                line.SetPosition(1, hitDirection);
                Debug.Log("Aiming");
            } else if(isFire) {
                //Add a gui element
                //Power increases and decreases from 0 to 1
                // when click mb1 it stops takes that float and multiplies it to hit force
                if(Input.GetMouseButtonDown(0)) {
                    isFire = false;
                    isAim = false;

                    hitForce = hitDirection * hitPower;
                    rb.AddForce(hitForce, ForceMode.Impulse);
                    line.enabled = false;
                }
            } else {
                Debug.Log("moving");
                if(!isMoving) {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;

                    isAim = true;
                    angle = 0;
                    hitDirection = Vector3.forward;

                    magnetized = false;

                    //turn ends here normally
                }
            }
        }
    }

    private void FixedUpdate() {
        doMagnetization();
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

        line.enabled = false;
    }

    public void activateMagnet() {
        magnetized = true;
    }

    private void DebugLog() {
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
        if(context.ReadValue<float>() > 0 && isAim) {
            //rotate right
            angle += 1;
            if(angle > 360) {
                angle = 0;
            }
        } else if(context.ReadValue<float>() < 0 && isAim) {
            //rotate left
            angle -= 1;
            if(angle < -360) {
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
    private void onDebug(InputAction.CallbackContext context) {
        DebugLog();
    }

    private void doMagnetization() {
        if(!magnetized) {
            return;
        }

        float distanceToHole = Vector3.Distance(transform.position, hole.MagnetPoint);
        if(distanceToHole > hole.MagnetRange && distanceToHole <= hole.MagnetDeadZone) {
            return;
        }

        float magnitude = rb.velocity.magnitude;
        Vector3 direction = (hole.MagnetPoint - transform.position).normalized;

        rb.velocity = direction * magnitude; // DIRECTION and MAGNITUDE
    }
}
