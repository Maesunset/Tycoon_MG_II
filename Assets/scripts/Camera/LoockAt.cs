using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoockAt : MonoBehaviour
{
    //variables privadas
    private Transform mainCamera;
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(mainCamera);
    }
}
