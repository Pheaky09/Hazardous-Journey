using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizantal;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private bool isFacingRight = true;


    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Animator anim;


    private enum MovementState { idle, running, jumping, falling }
    
    [SerializeField] private AudioSource jumpSound;

    private void Update()
    {
        MovementPlayer();
        UpdateAnimationState();
    }
    private void MovementPlayer()
    {
        horizantal = Input.GetAxisRaw("Horizontal");
        Flip();
        
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)) && IsGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //It jumps higher when you hold the jump button
        if ((Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.UpArrow)|| Input.GetKeyUp(KeyCode.W)) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
        }
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (Mathf.Abs(horizantal) > 0f)
        {
            state = MovementState.running;
        }
        else if (Mathf.Abs(horizantal) < 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);

    }
    private bool IsGrounded()
    {
        //It will check if the player is on the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizantal * speed, rb.velocity.y);

    }
    private void Flip()
    {
        //It will flip the player when you move left or right
        if (isFacingRight && horizantal < 0f || !isFacingRight && horizantal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}