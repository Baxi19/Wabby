using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int health = 3;
    public Image[] hearts;
    bool hasCoolDown = false;

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            if(GetComponent<PlayerMovement>().isGrounded){
                SubstractHealth();
            }
        }
    }
    
    
    // Substract Player's Health
    void SubstractHealth(){
        if(!hasCoolDown){
            if(health > 0){
                health--;
                hasCoolDown=true;
                StartCoroutine(CoolDown());
            }   
            if(health <= 0){
                //TODO: Change to 
                SceneChanger.ChangeSceneTo("LoseScene");
            }

            EmptyHeards();
        }
    }

    //Disable the heards 
    void EmptyHeards(){
        for (int i = 0; i < hearts.Length; i++)
        {
            if(health - 1 < i){
                hearts[i].gameObject.SetActive(false); 
            }
        }
    }

    // Cool Down .5 second
    IEnumerator CoolDown(){
       yield return new WaitForSeconds(.5f); 
       hasCoolDown = false;
       StopCoroutine(CoolDown());
    }
}
