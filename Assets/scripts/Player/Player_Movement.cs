using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //variables publicas
    public Transform cameraAim;
    public float walkSpeed, runSpeed, rotationSpeed;
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
            AlinePlayer();
        }
    }

    void Walk()
    {
        //get inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");

        //Normalizar 
        vectorMovement = vectorMovement.normalized;

        // acomodamos la direccion a la direccion de la camara 
        cameraAim.TransformDirection(vectorMovement);

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

    void AlinePlayer()
    {
        //
        if(chc.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vectorMovement),rotationSpeed*Time.deltaTime );
        }
    }
}
