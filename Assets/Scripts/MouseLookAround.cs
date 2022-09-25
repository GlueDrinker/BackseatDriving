using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAround : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;
    public float sensitivity = 15f;

        
    void FixedUpdate()
    {
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        
    }
}
