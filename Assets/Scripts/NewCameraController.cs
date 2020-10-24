using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform target, bazooka;
    float mouseX, mouseY;

    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void LateUpdate()
    {
        CamControl();
    }

    void CamControl() 
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        bazooka.rotation = Quaternion.Euler(mouseY, mouseX, 0);
     
    }
}
