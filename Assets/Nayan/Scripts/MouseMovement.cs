using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
 
    float xRotation = 0f;
    float yRotation = 0f;
 
    void Start()
    {
      //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
 
        //control rotation around x axis (Look up and down)
        xRotation -= mouseY;
 
        //we clamp the rotation so we cant Over-rotate (like in real life)
        xRotation = Mathf.Clamp(xRotation, -12f, 20f);
 
        //control rotation around y axis (Look up and down)
        yRotation += mouseX;

        yRotation = Mathf.Clamp(yRotation, -15f, 15f);
        //applying both rotations
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
