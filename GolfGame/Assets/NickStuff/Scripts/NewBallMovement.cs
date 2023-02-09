using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBallMovement : MonoBehaviour
{
    [SerializeField] private float shotPower;
    [SerializeField] private float stopVelocity = .05f; //The velocity below which the rigidbody will be considered as stopped
	[SerializeField] private LineRenderer lineRenderer;
    private bool isIdle;
    private bool isAiming;
    private Rigidbody rb;


    private void Awake() {
        rb = GetComponent<Rigidbody>();

        isAiming = false;
        lineRenderer.enabled = false;
    }

    private void FixedUpdate() {
        if(rb.velocity.magnitude < stopVelocity) {
            Stop();
        }

        ProcessAim();
    }

    private void OnMouseDown() {
        if (isIdle) {
            isAiming = true;
        }
    }
    private void ProcessAim() 
    {
        if(!isAiming || !isIdle) 
        {
            return;
        }

        Vector3 worldPoint = CastMouseClickRay();

        if (worldPoint == Vector3.negativeInfinity) 
        {
            Debug.Log("No Value");
            return;
        }
        else
        {
            DrawLine(worldPoint);
            Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);

            Vector3 direction = (horizontalWorldPoint - transform.position).normalized;
            float strength = Vector3.Distance(transform.position, horizontalWorldPoint)*40;

            if(strength <= 0)
            {
                strength = 0;
            }
            else if(strength >= 100)
            {   
                strength = 100;
            }

            //Add Gui here

            Debug.Log("Current Strength: " + strength);
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            Shoot(worldPoint);
        }
    }
    private void Shoot(Vector3 worldPoint) 
    {
        isAiming = false;
        lineRenderer.enabled = false;

        Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);

        Vector3 direction = (horizontalWorldPoint - transform.position).normalized;
        float strength = Vector3.Distance(transform.position, horizontalWorldPoint)*40;
        
        if(strength <= 0)
        {
            Stop();
            return;
        }
        else if(strength >= 100)
        {   
            strength = 100;
        }

        Debug.Log("Shoot Strength: " + strength);
        
        rb.AddForce(-direction * strength * shotPower);
        isIdle = false;
    }
    private void DrawLine(Vector3 worldPoint)
    {
        lineRenderer.SetPosition(0,gameObject.transform.position);
        lineRenderer.SetPosition(1,-worldPoint);
        
        lineRenderer.enabled=true;
    }
    private void Stop() 
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isIdle = true;
    }
    private Vector3 CastMouseClickRay() 
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;

        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, float.PositiveInfinity);
        
        if(hit.collider != null)
        {
            return hit.point;
        }
        else
        {
            return Vector3.negativeInfinity;
        }
    }
}
