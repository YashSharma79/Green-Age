using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActive : MonoBehaviour {

	// Use this for initialization
	public GameObject[] toCreate;
	public Vector3[] spawnerValues;
	public GameObject[] toDestroy;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Player here");
			for(int i = 0;i<toCreate.Length;i++)
				Instantiate (toCreate[i],spawnerValues[i],transform.rotation);
			Destroy (gameObject);
			for (int i = 0; i < toDestroy.Length; i++)
				toDestroy [i].SetActive (false);
		}
			
	}
		
}
