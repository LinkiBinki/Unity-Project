using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 2.0f;
    public float rotationSpeed = 4.0f;
    public float maxLookUpAngle = 80.0f; 
    public float maxLookDownAngle = 80.0f; 

    private float mouseX; 
    private float mouseY; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Camera.main.transform.localEulerAngles = Vector3.zero;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        RotateCamera();

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * movement;
        movement.Normalize();

        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void RotateCamera()
    {
        Vector3 cameraRotation = transform.localEulerAngles;
        cameraRotation.y += mouseX * rotationSpeed;
        transform.localEulerAngles = cameraRotation;

        Vector3 newCameraRotation = Camera.main.transform.localEulerAngles;
        newCameraRotation.x -= mouseY * rotationSpeed;
        newCameraRotation.x = Mathf.Clamp(newCameraRotation.x, -maxLookUpAngle, maxLookDownAngle);
        Camera.main.transform.localEulerAngles = newCameraRotation;
    }
    void RotatePlayer()
    {
        Vector3 playerRotation = transform.eulerAngles;
        playerRotation.y = transform.eulerAngles.y;
        transform.eulerAngles = playerRotation;
    }
}