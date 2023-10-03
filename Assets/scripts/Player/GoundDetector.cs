using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundDetector : MonoBehaviour
{
    //variables privadas
    public float radio;
    public LayerMask layer;
    // variables privadas
    private bool isGournded;

    void Update()
    {
        checkground();
    }
    void checkground()
    {
        isGournded = Physics.CheckSphere(transform.position,radio,layer);
    }

    public bool IsGrounded()
    {
        return isGournded;
    }
}
