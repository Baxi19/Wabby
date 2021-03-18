﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static int collectableQuantity = 0;
    public Text collectableText;
    ParticleSystem collectableParticle;

    // Start is called before the first frame update
    void Start()
    {
        collectableParticle = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            collectableParticle.transform.position = transform.position;
            collectableParticle.Play();
            gameObject.SetActive(false);
            collectableQuantity++;
            collectableText.text = collectableQuantity.ToString();
        }
    }
}
