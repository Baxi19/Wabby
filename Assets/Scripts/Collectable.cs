using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static int collectableQuantity = 0;
    public Text collectableText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            gameObject.SetActive(false);
            collectableQuantity++;
            collectableText.text = collectableQuantity.ToString();
        }
    }
}
