using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player") {
			SceneChanger.NextScene ();
		}
	}
}
