using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //variables publicas
    public Transform cameraAim;
    public float walkSpeed, runSpeed, rotationSpeed, jumpForce;
    public bool canMove;
    public GoundDetector GD;

    //variables privadas
    private Vector3 vectorMovement,verticalForce;
    private float speed, currentSpeed;
    private CharacterController chc;
    private bool isGrounded;

    private void Start()
    {
        //agarra el character controller
        chc = GetComponent<CharacterController>();
        //inicializa la velocidad y el vector
        speed = 0f;
        currentSpeed = 0f;
        vectorMovement = Vector3.zero;
        verticalForce = Vector3.zero;

    }

    private void Update()
    {
        if (canMove)
        {
            Walk();
            Run();
            AlinePlayer();
            jump();
        }
        Gravity();
        CheckGround();
    }

    void Walk()
    {
        //get inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");

        //Normalizar 
        vectorMovement = vectorMovement.normalized;

        // acomodamos la direccion a la direccion de la camara 
        vectorMovement = cameraAim.TransformDirection(vectorMovement);

        // Guardamos la velocidad actual con suavizado
        currentSpeed = Mathf.Lerp(currentSpeed, vectorMovement.magnitude * speed, 10f * Time.deltaTime);

        //Mover Player
        chc.Move(vectorMovement * currentSpeed * Time.deltaTime);

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
    void jump()
    {
        if (isGrounded && Input.GetAxis("Jump") > 0f)
        {
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
        }
    }

    //funcion provicional de gravedad
    void Gravity()
    {
        if(!isGrounded)
        {
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        {
            verticalForce = new Vector3(0f, -2f, 0f);
        }

        chc.Move(verticalForce * Time.deltaTime);
    }

    void AlinePlayer()
    {
        //
        if(chc.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, 
            Quaternion.LookRotation(vectorMovement),rotationSpeed*Time.deltaTime );
        }
    }

    void CheckGround()
    {
        isGrounded = GD.IsGrounded();
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
