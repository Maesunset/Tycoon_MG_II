using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //variables Publicas
    public float sensibility;
    public Transform cameraJoinY, targetObject;
    public bool canRotate;


    //variables Privadas
    private float XRotation, YRotation;

    void Start()
    {
        canRotate = true;
    }
    void Update()
    {
        if (canRotate)
            Rotate();

        FollowTarget();
    }

    void Rotate()
    {
        // conseguir inputs de movimiento de un mouse 
        XRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensibility;
        YRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * sensibility;

        // limite al eje y;
        YRotation = Mathf.Clamp(YRotation, -65, 65);

        // rotar x y y
        transform.localRotation = Quaternion.Euler(0f, XRotation, 0f);
        cameraJoinY.transform.localRotation = Quaternion.Euler(-YRotation, 0f, 0f);

    }

    void FollowTarget()
    {
        transform.position = targetObject.position;
    }
}
