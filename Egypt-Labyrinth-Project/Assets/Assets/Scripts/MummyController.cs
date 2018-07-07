using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class MummyController : MonoBehaviour {

	private Transform goal;
	private NavMeshAgent agent;
	public ParticleSystem Particula;
	public Image Vida;
	public Text ratioText;
	private float sangue = 100;
	public float lifeTotal;
	public float lifeAtual;
	private bool flagAttack = false;
	private bool flagMumia = false;
	private bool flagMorreu = false;

	void Start () {
		goal = GameObject.Find("Sphere").transform;
		agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position;
		MummyWalk();
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

	void OnCollisionExit(Collision col){
		
		if(flagMorreu == false){
			
			MummyWalk();			
		}
		else{
			MummyDie();
		}
	}

	void OnCollisionEnter(Collision col) {
		
		if(flagMorreu == false) {

			if(flagAttack == true) {

				if (col.gameObject.name == "MedievalSword") {	
		
					MummyHit();
					UpdateVidaMumia();
		
				}

				flagAttack = !flagAttack;

			}

			else if(col.gameObject.name == "Mummy" || col.gameObject.name == "Mumia" || col.gameObject.name == "Mumias"  ){
				flagMumia = !flagMumia;
				MummyWalk();

			}

			else if (col.gameObject.name == "Sphere") {
		
				MummyAttack(); 

			}
		}
	}

	void MummyWalk(){

		GetComponent<Animation> ().Play ("run");

	}

	void MummyAttack(){

		GetComponent<Animation> ().Play ("attack");	

	}

	void MummyHit(){
	
		GetComponent<Animation> ().Play ("jumpSplitted_F");
				
	}

	void MummyDie(){
		GetComponent<Animation> ().Play("die01");
	}


	private void UpdateVidaMumia(){
		
		lifeAtual -= 25;
		sangue -=25;
		Particula.Emit(10);

		if(lifeAtual <= 0 || sangue <= 0){
			lifeAtual = 0;
			sangue = 0;
			flagMorreu = true;
			MummyDie();
			StartCoroutine(Wait());	
			
		} 

		Vida.rectTransform.localScale = new Vector3 ((lifeAtual/lifeTotal), 1, 1);
		ratioText.text = sangue.ToString();
		
	}

	IEnumerator Wait(){
		Particula.Emit(200);   
		yield return new WaitForSeconds (1.0f);
		StartCoroutine(Wait());
		Destroy(gameObject);

	}

}
