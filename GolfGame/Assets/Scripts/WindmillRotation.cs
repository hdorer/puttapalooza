using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillRotation : MonoBehaviour
{
    [SerializeField] private GameObject rotatableWings;
    [SerializeField] private float rotateSpeed = 50f;
    void Update()
    {
        rotatableWings.transform.RotateAround(rotatableWings.transform.position, rotatableWings.transform.forward, rotateSpeed * Time.deltaTime);
    }
}
