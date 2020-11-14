using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBlock : MonoBehaviour {
	public float timeBetweenAttacks;
	public float attackDamage;
	public GameObject env;
	public ParticleSystem ps;
	float timer = 0f;
	Environment environment;
	int whiteCount = 0;
	ParticleSystem.EmissionModule em;
	void Start(){
		environment = env.GetComponent<Environment> ();
		em = ps.emission;
	}

	void Update(){
		timer += Time.deltaTime;
		if (whiteCount > 0) {
			em.enabled = true;

			if (timer >= timeBetweenAttacks) {
				attackDamage *= whiteCount;
				Attack ();
			}
		}

		if (whiteCount == 0)
			em.enabled = false;
		
	}

	void OnTriggerEnter(Collider other){
		Debug.Log (other.gameObject.tag + " at the cloud");
		if (other.gameObject.tag == "White") {
			whiteCount++;
		}
	}
		
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "White") {
			whiteCount--;
		}
		
	}

	void Attack(){
		timer = 0f;

		if (environment.currentHealth > 0)
			environment.TakeDamage (attackDamage);
	}
}