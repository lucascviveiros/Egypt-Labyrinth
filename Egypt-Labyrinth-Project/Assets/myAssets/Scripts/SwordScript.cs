using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {
	
	// Update is called once per frame

	
	void Update () {
	
		if (Input.GetButtonDown ("Fire2")) {

			AudioSource som = GetComponent<AudioSource> ();
			som.Play ();

		}
	}

	void OnCollisionEnter(Collision col){
		
		if (col.gameObject.tag == "Mumias") {
			//var hit = col.gameObject;
			//Destroy (hit);
		}

		if (col.gameObject.name == "Egypt-Labyrinth"){
			//print("player toco labirinto");
//			transform.position = new Vector3(0.48,-0,64, 1.49);

			
		}		
        
			
	}

}
