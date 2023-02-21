using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    //SerializeField Items
    [SerializeField] private InputAction aim;
    [SerializeField] private InputAction confirm;
    [SerializeField] private InputAction goBack;
    [SerializeField] private InputAction fire;
    [SerializeField] private InputAction doDebug;
        //Non Input Actions
    [SerializeField] private float stoppingSpeed = 0.01f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LineRenderer line;
    [SerializeField] private float hitPower;
    [SerializeField] private Hole hole;


    //Bools
    private bool isAim = true;
    private bool isFire = false;
    private bool isTurn = true;
    private bool magnetized;
    private bool toOne = true;
    public bool IsAim { get => isAim; }
    //There is a problem with isMoving. It instantly becaomes false right after you hit the ball. Would have to change this to something in 
    public bool isMoving { get => rb.velocity.magnitude >= stoppingSpeed; }

    //Floats
    private float turnFloat;
    private float angle = 0;
    public float hitStrength = 0;

    //Vector3
    private Vector3 hitDirection = Vector3.forward;
    private Vector3 hitForce = Vector3.zero;
    
    private void OnEnable() {
        aim.Enable();
        confirm.Enable();
        goBack.Enable();
        fire.Enable();
        doDebug.Enable();

        aim.performed += onAim;
        aim.canceled += onAim;
        confirm.performed += onConfirm;
        goBack.performed += onGoBack;
        fire.performed += onFire;
        doDebug.performed += onDebug;
    }

    private void Update() {
        if(!isTurn) {
            return;
        }

        if(isAim) {

            if(turnFloat > 0)
            {
                angle++;
            }
            else if(turnFloat < 0)
            {
                angle--;
            }

            if(angle > 360 || angle < -360)
            {
                angle = 0;
            }

            hitDirection = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward;

            line.enabled = true;
            line.SetPosition(0, new Vector3(0,0,0));
            line.SetPosition(1, hitDirection);
            Debug.Log("Aiming");
            hitStrength = 0;
        } 
        else if(isFire) {
            //I dont like this set up, but it is the best i have so far.
            if(hitStrength < 1 && toOne)
            {
                hitStrength += .001f;
                if(hitStrength >= 1)
                {
                    toOne = false;
                }
            }
            else if(hitStrength > 0 && !toOne)
            {
                hitStrength -= .001f;
                if(hitStrength <= 0)
                {
                    toOne = true;
                }
            }

        } 
        else {
            Debug.Log("moving");
            if(!isMoving) 
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                isAim = true;
                angle = 0;
                hitDirection = Vector3.forward;

                magnetized = false;
                line.enabled = false;

                //turn ends here normally
            }
        }
    }

    private void FixedUpdate() {
        doMagnetization();
    }

    private void OnDisable() {
        aim.performed -= onAim;
        aim.canceled -= onAim;
        confirm.performed -= onConfirm;
        goBack.performed -= onGoBack;
        fire.performed -= onFire;
        doDebug.performed -= onDebug;

        aim.Disable();
        confirm.Disable();
        goBack.Disable();
        fire.Disable();
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
        turnFloat = context.ReadValue<float>();
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

    private void onFire(InputAction.CallbackContext context) {
        if(!isFire) {
            return;
        }

        isFire = false;
        isAim = false;

        hitForce = hitDirection * (hitPower * hitStrength);
        rb.AddForce(hitForce, ForceMode.Impulse);
        line.enabled = false;
    }
}
