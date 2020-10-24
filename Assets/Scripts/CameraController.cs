using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraMode mode;

    [Header("Propiedades")]
    public float lookSpeed = 2.0f;
    [Tooltip("Limita que tan abajo puede mirar el jugador. El valor debe ser negativo")]
    [Range(-80,-10)]
    public float lookDownAngleLimit = -60;
    [Tooltip("Limita que tan arriba puede mirar el jugador. El valor debe ser positivo")]
    [Range(10, 85)]
    public float lookUpAngleLimit = 60;

    [Header("Metodo Default")]
    public Transform playerCameraParent;

    private Vector2 rotation = Vector2.zero;
    private Camera cam;
    private float xRot;

    void Start()
    {
        cam = GetComponent<Camera>();
        rotation.y = transform.eulerAngles.y;
        
    }

    
    void Update()
    {
        switch(mode)
        {
            case CameraMode.DEFAULT:
                MetodoDefault();
                break;
            case CameraMode.SIMPLE:
                MetodoSimple();
                break;
        }
        

    }

    private void MetodoSimple()
    {
        //Debug.Log("Moving cam");
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, lookDownAngleLimit, lookUpAngleLimit);
        cam.transform.localRotation = Quaternion.Euler(xRot, cam.transform.localRotation.eulerAngles.y, 0);
        transform.Rotate(Vector3.up, mouseX);
    }

    private void MetodoDefault()
    {
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotation.x = Mathf.Clamp(rotation.x, lookDownAngleLimit, lookUpAngleLimit);
        playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        transform.eulerAngles = new Vector2(0, rotation.y);
    }
}
public enum CameraMode
{
    DEFAULT,
    SIMPLE
}
