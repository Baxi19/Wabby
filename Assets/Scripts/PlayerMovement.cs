﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody2D playerRb;
    public float speed = 6.0f;
    public float jumpSpeed = 150f;
    public bool isGrounded = true;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);
        
        if(Input.GetAxis("Horizontal") == 0){
            playerAnimator.SetBool("isWalking", false);
        }else if(Input.GetAxis("Horizontal") < 0){
            playerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }else if(Input.GetAxis("Horizontal") > 0){
            playerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                GetComponent<AudioSource>().Play();
                playerRb.AddForce(Vector2.up * jumpSpeed);
                isGrounded = false;
                playerAnimator.SetTrigger("jump");
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }
}
