using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    private void Awake() 
    {
        Debug.Log("Player Controller Awake");
    }

    // Update is called once per frame
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Math.Abs(speed));
        Vector3 scale = transform.localScale;

        if (speed<0)
        {
            scale.x = -1f * Math.Abs(scale.x); // mirror for left run flip
        }
        else if (speed >0)
        {
            scale.x = Math.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}
