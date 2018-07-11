using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VidaController : MonoBehaviour {

	public Image Vida;
	public Text ratioText;
	public float lifeTotal;
	public float lifeAtual;
	public float sangue = 100;
	public int tipoUpdate = 0;
	public bool flagAttack = false;

	void Start () {

		lifeAtual = lifeTotal;
	}

	void Update(){
		if (Input.GetButtonDown ("Fire2")) {
		}
	}

	void OnCollisionEnter(Collision col){
		
		//if(flagAttack == false){
		
			if (col .gameObject.name == "Mumias" || col.gameObject.name == "Mumia" ||col.gameObject.name == "MumiasRun" ) {	
				tipoUpdate = 0;
				UpdateVida(tipoUpdate);
		
			}

			else if (col.gameObject.name == "Pharaoh" || col.gameObject.name == "Armature"){
				tipoUpdate = 1;
				UpdateVida(tipoUpdate);
			}
		//}

		else if (col.gameObject.name == "Heart"){
			//print("Aumenta vida!");
			tipoUpdate = 2;
			Destroy(GameObject.Find("Heart"));
			if(lifeAtual < 100){
				UpdateVida(tipoUpdate);
			}
		}

		else if (col.gameObject.name == "Cube"){
			
			Destroy(GameObject.Find("Cube"));
			Destroy(GameObject.Find("Trap"));
		}

	}

	private void UpdateVida(int tipoUpdate){
		
		if(tipoUpdate == 0){
			lifeAtual -=5;
			sangue -=5;
			AudioSource dor = GetComponent<AudioSource> ();
			dor.Play();
		}
		else if(tipoUpdate == 1){
			lifeAtual -=15;
			sangue -=15;
			tipoUpdate = 0;
			AudioSource dor = GetComponent<AudioSource> ();
			dor.Play();
		}
		else if (tipoUpdate == 2){
			lifeAtual = 100 ;
			sangue = 100;
		}
		
		if(lifeAtual < 0 || sangue < 0){
			lifeAtual = 0;
			sangue = 0;
			ExitGame();
			
		
		} else{
			
			Vida.rectTransform.localScale = new Vector3 ((lifeAtual/lifeTotal), 1, 1);
			ratioText.text = sangue.ToString();
		}
	}

	private void ExitGame(){
	#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
	}

}
