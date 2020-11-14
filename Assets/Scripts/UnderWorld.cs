using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWorld : MonoBehaviour {
	public Camera downCamera;
	public bool over = false;
	public GameObject downGround;
	public GameObject downBackground;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Player here");
			Destroy (GameObject.Find("Tool"));
			Instantiate (downGround,other.transform.position + new Vector3(100f,-30f,0f),Quaternion.identity);
			Instantiate (downBackground,other.transform.position,Quaternion.identity);
			Camera.main.enabled = false;
			downCamera.enabled = true;
			over = true;
			Destroy (gameObject);
		}
	}
}
