using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    //variables Publicas

    public float speed;

    //Variables privadas 
    private Vector3 movementVector;


    void Start()
    {
        // inicializar vector
        movementVector = transform.forward * speed;
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Resource"))
        {
            Transform collidedObject = other.gameObject.transform;
            collidedObject.position = new Vector3(collidedObject.position.x+movementVector.x*Time.deltaTime,
                                                  collidedObject.position.y + movementVector.y * Time.deltaTime,
                                                  collidedObject.position.z + movementVector.z * Time.deltaTime);

        }
    }
}
