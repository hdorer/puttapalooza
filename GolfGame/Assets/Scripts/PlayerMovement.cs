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
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LineRenderer line;
    [SerializeField] private float hitPower;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float stoppingSpeed = 0.01f;
    [SerializeField] private float hitStrength = 0.0f;
    [SerializeField] private Hole hole;
    [SerializeField] private PowerSliderScript powSlider;

    //Bools
    private bool isAim = true;
    public bool IsAim { get => isAim; }
    private bool isFire = false;
    private bool isTurn = true;
    private bool magnetized;
    public bool isMoving = false;

    //Floats
    private float turnFloat;
    private float angle = 0;
    private float hitStrengthSign = 1;

    //Vector3
    private Vector3 hitDirection = Vector3.forward;
    private Vector3 hitForce = Vector3.zero;
    private Vector3 lastPosition;

    private void OnEnable() {
        aim.Enable();
        confirm.Enable();
        goBack.Enable();
        fire.Enable();
        doDebug.Enable();
        powSlider.gameObject.SetActive(false);
        lastPosition = gameObject.transform.position;

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
            angle += turnFloat * turnSpeed * Time.deltaTime;
            if(angle > 360 || angle < -360) {
                angle = 0;
            }

            hitDirection = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward;

            line.enabled = true;
            line.SetPosition(0, new Vector3(0, 0, 0));
            line.SetPosition(1, hitDirection);
            hitStrength = 0;
        } else if(isFire) {
            //I dont like this set up, but it is the best i have so far.
            hitStrength += .3f * hitStrengthSign * Time.deltaTime;
            if(hitStrength >= 1 || hitStrength <= 0) {
                hitStrengthSign *= -1;
            }
            powSlider.ChangeFill(hitStrength);
        } else {
            Debug.Log("moving");
            if(!isMoving) {
                StopCoroutine(CheckMoving());
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                transform.rotation = Quaternion.identity; // quick and dirty fix
                angle = 0;
                hitDirection = Vector3.forward;

                magnetized = false;
                line.enabled = false;
                isAim = true;

                // isTurn = false; //Ping Tunr System

                lastPosition = gameObject.transform.position;

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

    ///Inumerator
    private IEnumerator CheckMoving() {
        Debug.Log("CheckMoving()");

        while(isMoving) {
            yield return new WaitForSeconds(1.0f);

            if(rb.velocity.magnitude < stoppingSpeed) {
                isMoving = false;
                isAim = true;
            }
        }
    }

    ///Input Actions
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
        powSlider.gameObject.SetActive(true);
    }

    //This is to go from hitting the ball to item and aim
    private void onGoBack(InputAction.CallbackContext context) {
        Debug.Log("go back");
        isAim = true;
        isFire = false;
        hitStrength = 0;
        hitStrengthSign = 1;
        powSlider.gameObject.SetActive(false);
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
        isMoving = true;

        StartCoroutine(CheckMoving());

        hitForce = hitDirection * (hitPower * hitStrength);
        Debug.Log(hitForce);
        rb.AddForce(hitForce, ForceMode.Impulse);
        hitStrength = 0;
        hitStrengthSign = 1;
        hitDirection = Vector3.forward;
        line.enabled = false;
        powSlider.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Reset")) {
            StopCoroutine(CheckMoving());
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            angle = 0;
            hitDirection = Vector3.forward;

            magnetized = false;
            line.enabled = false;

            isTurn = false; //Send Ping To Turn System
            gameObject.transform.position = lastPosition;
        }
    }
}
