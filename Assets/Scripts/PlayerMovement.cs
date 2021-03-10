using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody2D playerRb;
    public float speed = 6.0f;
    public float jumpSpeed = 150f;
    bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);
        
        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                playerRb.AddForce(Vector2.up * jumpSpeed);
                isGrounded = false;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }
}
