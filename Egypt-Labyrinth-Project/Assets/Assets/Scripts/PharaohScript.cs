using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PharaohScript : MonoBehaviour {

	private Transform goal;
	private NavMeshAgent agent;
	//public GameObject Alvo;
	public Image Vida;
	public Text ratioText;
	private float sangue = 100;
	public ParticleSystem Particula;
	public float lifeTotal;
	public float lifeAtual;
	private bool flagAttack = false;
	private bool flagMumia = false;
	private bool flagMorreu = false;


	void Start () {
		
		goal = GameObject.Find("Sphere").transform;
		agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position;
		PharaohWalk();
		lifeAtual = lifeTotal;

	}

	void Update () {

		if(flagMorreu == false){
			goal = GameObject.Find("Sphere").transform;
			agent = GetComponent<NavMeshAgent>();
			agent.destination = goal.position;

		}

		if (Input.GetButtonDown ("Fire2")) {
			flagAttack = !flagAttack;
		}

	}

	
	void PharaohWalk(){

		if(flagMorreu == false){
		GetComponent<Animation> ().Play ("Walk_Weaponless");
		}
	}

	void PharaohAttack(){
		GetComponent<Animation> ().Play ("Atack_Spear");

	}

	void PharaohHit(){
		GetComponent<Animation> ().Play ("GetDamage_Spear");


	}

	void PharaohDie(){
		GetComponent<Animation> ().Play ("DieSpear");
		
	}

	void OnCollisionExit(Collision col){
		
		if(flagMorreu == false){
			
			PharaohWalk();			
		}
	}

	void OnCollisionEnter(Collision col) {
		
		if(flagMorreu == false) {

			if(flagAttack == true) {

				if (col.gameObject.name == "MedievalSword") {	
		
					PharaohHit();
					UpdateVidaPharaoh();
		            
				}

				flagAttack = !flagAttack;

			}

			else if(col.gameObject.name == "Mummy" || col.gameObject.name == "Mumia" || col.gameObject.name == "Mumias"  ){
				flagMumia = !flagMumia;
			}

			else if (col.gameObject.name == "Sphere") {
		
				AudioSource risada = GetComponent<AudioSource> ();
				risada.Play ();	
				PharaohAttack();
                StartCoroutine(WaitAttack());

			}
		}
	}
	

	private void UpdateVidaPharaoh(){
		lifeAtual -= 15;
		sangue -=15;
		
		if(lifeAtual <= 0 || sangue <= 0){
			lifeAtual = 0;
			sangue = 0;
			flagMorreu = !flagMorreu;
			GetComponent<Animation>().Stop();
			PharaohDie();
			StartCoroutine(Wait());	
			
			Particula.Emit(10000);
		
		} 
		
		Vida.rectTransform.localScale = new Vector3 ((lifeAtual/lifeTotal), 1, 1);
		ratioText.text = sangue.ToString();
		
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (1.5f);
		StartCoroutine(Wait());  
		GetComponent<Animation>().Stop();
		Destroy(gameObject);
		ExitGame();
	}	

    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(WaitAttack());
    }
		
	private void ExitGame() 
	{
	#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
	}
}
