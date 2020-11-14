using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

	public GameObject bridge;
	void OnTriggerEnter(Collider other){
		if (other.transform.parent != null && other.transform.parent.tag == "bacteria") {
			Destroy (other.gameObject);
			Destroy (bridge);
		}
	}

}
