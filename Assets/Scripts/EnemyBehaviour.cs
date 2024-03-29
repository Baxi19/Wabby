﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D enemyRb;
    SpriteRenderer enemySr;
    Animator enemyAnimator;
    float timeBeforeChange;
    public float delay = 2.5f;
    public float speed = 1.0f;
    
    ParticleSystem enemyParticle;
    AudioSource deadAudio;

    // Start is called before the first frame update
    void Start()
    {
        deadAudio = GetComponentInParent<AudioSource>();
        enemyParticle = GameObject.Find("EnemyParticle").GetComponent<ParticleSystem>();
        enemyRb = GetComponent<Rigidbody2D>();
        enemySr = GetComponent<SpriteRenderer>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.velocity = Vector2.right * speed;

        if(speed > 0){
            enemySr.flipX = false;
        }else if(speed < 0){
            enemySr.flipX = true;
        }

        if(timeBeforeChange < Time.time){
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            if(transform.position.y + .03f < collision.transform.position.y){
                enemyParticle.transform.position = transform.position;
                enemyParticle.Play();
                deadAudio.Play();
                enemyAnimator.SetBool("isDead", true);
            }
        }
    }

    public void DisableEnemy(){
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
