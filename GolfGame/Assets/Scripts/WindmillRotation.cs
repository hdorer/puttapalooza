using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillRotation : MonoBehaviour
{
    [SerializeField] private GameObject rotatableWings;
    [SerializeField] private float rotateSpeed = 1.5f;
    void Update()
    {
        rotatableWings.transform.RotateAround(Vector3.zero, Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
