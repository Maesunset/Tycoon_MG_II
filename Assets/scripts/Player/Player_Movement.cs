using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //variables
    public float walkSpeed, runSpeed;
    public bool canMove;

    //variables privadas
    private Vector3 vectorMovement;
    private float speed;
    private CharacterController chc;

    private void Start()
    {
        //agarra el character controller
        chc = GetComponent<CharacterController>();
        //inicializa la velocidad y el vector
        speed = walkSpeed;
        vectorMovement = Vector3.zero;

    }

    private void Update()
    {
        if (canMove)
        {
            Walk();
            Run();
        }
    }

    void Walk()
    {
        //get inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");

        //Normalizar 
        vectorMovement = vectorMovement.normalized;

        //Mover Player
        chc.Move(vectorMovement * speed * Time.deltaTime);

    }

    void Run()
    {
        //modificar la velocidad al precionar correr
        if (Input.GetAxis("Run") > 0f)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }

    //funcion provicional de gravedad
    void Gravity()
    {
        chc.Move(new Vector3(0f, -4f, 0f));
    }
}
