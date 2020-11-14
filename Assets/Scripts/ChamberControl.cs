using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberControl : MonoBehaviour {
	public GameObject stone;
	private Rigidbody stoneBody;
	void Start(){
		stoneBody = stone.GetComponent<Rigidbody> ();
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			stoneBody.isKinematic = false;
			stoneBody.useGravity = true;
		}
	}
}
