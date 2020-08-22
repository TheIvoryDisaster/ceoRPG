using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    /*
    void Start()
    {
        //Locks the cursor to the center of the screen so it doesnt leave the game window.
        Cursor.lockState = CursorLockMode.Locked;
    }


    // From Brackeys tutorial "FIRST PERSON MOVEMENT in Unity - FPS Controller"
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Prevents the camera from rotating all the way around on the y axis.

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    */
}
