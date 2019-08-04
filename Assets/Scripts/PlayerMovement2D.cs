using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    private CharacterController2D controller;
    private Animator animator;
    private Rigidbody2D rb;
    [Range(1, 100)] public float runSpeed = 40f;
    private bool isJumping = false;
    private bool isCrouching = false;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<CharacterController2D>();
    }

    void Update()
    {

        if (Input.GetButton("Jump"))
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButton("Crouch"))
        {
            isCrouching = true;
            animator.SetBool("IsCrouching", true);
        }else
        {
            isCrouching = false;
            animator.SetBool("IsCrouching", false);
        }

        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("IsAttacking", true);
        }

        animator.SetFloat("HorizontalVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("VerticalVelocity", rb.velocity.y);
        //animator.SetBool("")
    }

    private void FixedUpdate()
    {
        controller.Move(Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime, isCrouching, isJumping);
        isCrouching = false;
        isJumping = false;
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsAttacking", false);
    }

    public void OnLanding()
    {
        animator.SetFloat("VerticalVelocity", 0);
    }
}
