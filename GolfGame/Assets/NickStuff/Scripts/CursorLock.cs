using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    bool Locked = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Locked = true;
    }
    void Update()
    {
        //Press the space bar to apply no locking to the Cursor
        if (Input.GetKey(KeyCode.Escape))
        {
            if(Locked)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            if(!Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
            
    }
}
