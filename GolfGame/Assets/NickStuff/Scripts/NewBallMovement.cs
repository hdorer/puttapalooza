using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class NewBallMovement : MonoBehaviour
{
    [SerializeField] private float shotPowerScalar;
    [SerializeField] private float stopVelocity; //The velocity below which the rigidbody will be considered as stopped
    [SerializeField] private bool isIdle;
    public bool IsIdle { get => isIdle; }
    [SerializeField] private bool isAiming;
    public bool IsAiming { get => isAiming; }
    [SerializeField] private bool isMagnetized;
    public bool IsMagnetized { set { isMagnetized = value; } }

    private Vector2 pressPoint;
    private Vector2 releasePoint;

    [SerializeField] private Transform cameraPivot;
    [SerializeField] private Hole hole;
    
    private Rigidbody rb;

    public UnityEvent onMovementStateUpdate;

    private void Awake() {
        rb = GetComponent<Rigidbody>();

        isIdle = true;
        isAiming = false;
        isMagnetized = false;

        //lineRenderer.enabled = false;
    }

    private void FixedUpdate() {
        
    }

    private void Update()
    {
        if(isIdle)
        {
            ProcessAim();
        }
        else
        {
            if(rb.velocity.magnitude < stopVelocity) 
            {
                Stop();
            }
            magnetize();
        }
    }

    private void OnMouseDown() {
        if(isIdle) {
            isAiming = true;
            onMovementStateUpdate?.Invoke();

            pressPoint = Input.mousePosition;
        }
    }
    private void ProcessAim() 
    {        
        //if(!isAiming || !isIdle) {
        //    Debug.Log("!isAiming || !isIdle");
        //    return;
        //}

        Vector2 screenDifference;
        Vector3 shotDirection;
        float shotMagnitude;
        Vector3 shotForce;

        //if(Input.GetMouseButtonDown(0)) 
        //{
        //    if(isIdle) {
        //        isAiming = true;
        //        onMovementStateUpdate?.Invoke();

        //        pressPoint = Input.mousePosition;
        //    }
        //}
        if(Input.GetMouseButtonUp(0)) 
        {
            isIdle = false;
            if(isAiming) 
            {
                releasePoint = Input.mousePosition;
                Debug.Log("press: " + pressPoint + " release: " + releasePoint);

                screenDifference = releasePoint - pressPoint;
                screenDifference = Vector2.ClampMagnitude(screenDifference, Screen.height / 4);
                shotDirection = Vector3.Normalize(new Vector3(screenDifference.x, 0, -screenDifference.y));
                shotMagnitude = 1 * (screenDifference.magnitude / (Screen.height / 2)) * shotPowerScalar;
                shotForce = shotDirection * shotMagnitude;
                shotForce = Quaternion.AngleAxis(cameraPivot.rotation.eulerAngles.y, Vector3.up) * shotForce;

                isAiming = false;
                isIdle = false;
                onMovementStateUpdate?.Invoke();

                rb.AddForce(shotForce);
            }
        }

        //Vector3 worldPoint = CastMouseClickRay();

        //if (worldPoint == Vector3.negativeInfinity) 
        //{
        //    Debug.Log("No Value");
        //    return;
        //}
        //else
        //{
        //    DrawLine(worldPoint);
        //    Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);

        //    Vector3 direction = (horizontalWorldPoint - transform.position).normalized;
        //    float strength = Vector3.Distance(transform.position, horizontalWorldPoint)*40;

        //    if(strength <= 0)
        //    {
        //        strength = 0;
        //    }
        //    else if(strength >= 100)
        //    {   
        //        strength = 100;
        //    }

        //    //Add Gui here

        //    Debug.Log("Current Strength: " + strength);
        //}
        //if (Input.GetMouseButtonUp(0)) 
        //{
        //    Shoot(worldPoint);
        //}
    }
    //private void Shoot(Vector3 worldPoint) 
    //{
    //    isAiming = false;
    //    onMovementStateUpdate?.Invoke();
    //    lineRenderer.enabled = false;

    //    Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);

    //    Vector3 direction = (horizontalWorldPoint - transform.position).normalized;
    //    float strength = Vector3.Distance(transform.position, horizontalWorldPoint)*40;
        
    //    if(strength <= 0)
    //    {
    //        Stop();
    //        return;
    //    }
    //    else if(strength >= 100)
    //    {   
    //        strength = 100;
    //    }

    //    Debug.Log("Shoot Strength: " + strength);
        
    //    rb.AddForce(-direction * strength * shotPower);
    //    isIdle = false;
    //    onMovementStateUpdate?.Invoke();
    //}
    private void DrawLine(Vector3 worldPoint)
    {
        //lineRenderer.SetPosition(0, gameObject.transform.position);
        //lineRenderer.SetPosition(1, worldPoint);
        
        //lineRenderer.enabled=true;
    }
    private void Stop() 
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isIdle = true;
        isAiming = false;
        isMagnetized = false;
        onMovementStateUpdate?.Invoke();
    }
    //private Vector3 CastMouseClickRay() 
    //{
    //    Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.farClipPlane);
    //    Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane);
    //    Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
    //    Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
    //    RaycastHit hit;

    //    Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, float.PositiveInfinity);
        
    //    if(hit.collider != null)
    //    {
    //        return hit.point;
    //    }
    //    else
    //    {
    //        return Vector3.negativeInfinity;
    //    }
    //}

    private void magnetize() {
        if(!isMagnetized) {
            // Debug.Log("not magnetized");
            return;
        }

        if(Vector3.Distance(transform.position, hole.transform.position) > hole.MagnetRange) {
            // Debug.Log(Vector3.Distance(transform.position, hole.transform.position) + " > " + hole.MagnetRange);
            return;
        }

        Debug.Log("Magnetizing");

        float magnitude = rb.velocity.magnitude;
        Vector3 direction = (hole.transform.position - transform.position).normalized;

        rb.velocity = direction * magnitude;
    }
}
