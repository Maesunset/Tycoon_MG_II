using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // variables publicas 
    public Player_Movement PM;
    public GoundDetector GD;

    // variables privadas
    private float speed;
    private bool isGrounded;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        speed = 0f;
        isGrounded = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        CheckSpeed();
        SetParameter();
    }

    void SetParameter()
    {
        animator.SetFloat("Speed", speed);
        animator.SetBool("IsGrounded", isGrounded);
    }

    public void CheckSpeed()
    {
        speed = PM.GetCurrentSpeed();
    }

    public void CheckGrounded()
    {
        isGrounded = GD.IsGrounded();
    }
}
