using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb2d;
    public float speed; // player horizontal speed
    public float jump; // player verical jump height

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        // move and play the animation
        MoveCharacter(horizontal, vertical);
        MovementAnimation(horizontal, vertical);
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        // Horizontal - move
        Vector3 position = transform.position; //local variable to store player position
        position.x = position.x + horizontal*speed*Time.deltaTime; // get the horizontal part of the vector - distance = speed * time * our raw input
        transform.position = position; // add the new x part to the existing x position

        // Vertical - jump
        if(vertical >0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void MovementAnimation(float horizontal, float vertical)
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
        
        // for Jump
        if(vertical >0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }   
    }
}
