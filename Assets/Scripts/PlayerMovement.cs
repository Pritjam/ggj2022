using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    public Animator animator;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
        Movement();

    }

    private void Movement()
    {
        rb.velocity = new Vector2(moveDirection * movespeed, rb.velocity.y);
    }

    private void Animate()
    {
        if ((moveDirection > 0 && !facingRight) || (moveDirection < 0 && facingRight))
        {
            FlipCharacter();
        }
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
    }

    private void FlipCharacter() {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
