using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTrigger : MonoBehaviour {

	// Use this for initialization
	GameObject b;
	BacteriaManager bm;
	void Start(){
		b = GameObject.Find("Bacteria");
		bm = b.GetComponent<BacteriaManager> ();
	}
	void OnTriggerEnter(Collider other){
		Debug.Log (other.gameObject.tag+" HERE");
		if (other.gameObject.tag == "Player") {
			bm.bacteriaCount = 3;

		}
	}
}
