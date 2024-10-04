using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{

    public Transform pointA;  // Patrol start point
    public Transform pointB;  // Patrol end point
    public float speed = 2f;
    public Animator animator;

    private Vector3 target;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        target = pointB.position;  // Initially move towards point B
        animator.SetBool("Patrol", true);
    }

    private void Update()
    {
        Patrol();
        FlipSprite();
    }

    private void Patrol()
    {
        // Move the enemy towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Switch target when the enemy reaches the current target point
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void FlipSprite()
    {
        // Flip the sprite based on the direction of movement
        if (target == pointB.position)
        {
            // Move towards point B (face right)
            spriteRenderer.flipX = false;
        }
        else
        {
            // Move towards point A (face left)
            spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.GetComponent<Player_Controller>() != null)
        {
            Player_Controller player_Controller = other.gameObject.GetComponent<Player_Controller>();
            player_Controller.KillPlayer();
        }
    }
}
