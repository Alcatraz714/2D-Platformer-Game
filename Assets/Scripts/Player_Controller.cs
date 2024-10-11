using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb2d;
    public Score_Controller score_Controller;
    public Level_Controller level_Controller;
    public GameOver_Controller gameOver_Controller;
    public int HP = 3;
    public float speed; // player horizontal speed
    public float jump; // player vertical jump height

    private int jumpCount = 0; // Track how many jumps the player has made
    private bool canDoubleJump = false; // To check if the player can double jump

    private void Awake() 
    {
        animator.SetBool("Alive", true);    
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool jumpPressed = Input.GetButtonDown("Jump"); 

        // Reset jump count when player is falling slowly or grounded (we assume this means they've landed)
        if (rb2d.velocity.y == 0)
        {
            jumpCount = 0;
            canDoubleJump = true;
        }

        // move and play the animation
        MoveCharacter(horizontal, jumpPressed);
        MovementAnimation(horizontal);
    }

    public void ReduceHP()
    {
        HP -= 1;
        if (HP <= 0)
        {
            KillPlayer();
        }
    }

    public void PickupKey()
    {
        Debug.Log("key picked up by the player");
        score_Controller.IncreaseScore();
    }

    public void KillPlayer()
    {
        Debug.Log("Player died");
        animator.SetBool("Alive", false);
        gameOver_Controller.PlayerDied();
        this.enabled = false;
    }

    private void MoveCharacter(float horizontal, bool jumpPressed)
    {
        // Horizontal - move
        Vector3 position = transform.position; //local variable to store player position
        position.x = position.x + horizontal * speed * Time.deltaTime; // get the horizontal part of the vector
        transform.position = position; // add the new x part to the existing x position

        // Jump logic
        if (jumpPressed && jumpCount < 1)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump); // First jump
            jumpCount++;
        }
        else if (jumpPressed && jumpCount == 1 && canDoubleJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump); // Double jump
            canDoubleJump = false; // Disable further jumps until grounded
        }
    }

    private void MovementAnimation(float horizontal)
    {
        // For horizontal movement
        animator.SetFloat("Speed", Math.Abs(horizontal));
        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Math.Abs(scale.x); // mirror for left run flip
        }
        else if (horizontal > 0)
        {
            scale.x = Math.Abs(scale.x);
        }
        transform.localScale = scale;
        
        // Set Jumping animation based on vertical velocity
        animator.SetBool("Jump", rb2d.velocity.y != 0);   
    }
}
